using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class SaleService : ServiceBase, ISaleService
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public SaleService(IRepositoryWrapper repository, IMapper mapper, IServiceWrapper serviceWrapper) : base(repository)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        public void AcceptInventory(SaleItemSummaryDTO saleItem)
        {
            var saleItemFound = _repository.SaleItemRepository.GetSaleItemsFromList(_mapper.Map<List<SaleItem>>(new List<SaleItemSummaryDTO> { saleItem })).FirstOrDefault();

            var stock = _repository.StockRepository.FindByCondition(x => x.ProductId == saleItemFound.ProductId).FirstOrDefault();

            stock.Quantity += saleItemFound.Quantity;

            saleItemFound.RefundStatus = RefundStatus.Finalized;

            _repository.StockRepository.Update(stock);
            _repository.SaleItemRepository.Update(saleItemFound);
            _repository.Save();
        }

        public void ChangeRefundStatus(SaleItemSummaryDTO saleItem, RefundStatus refundStatus)
        {
            var saleItemsFound = _repository.SaleItemRepository.GetSaleItemsFromList(_mapper.Map<List<SaleItem>>(new List<SaleItemSummaryDTO> { saleItem })).FirstOrDefault();

            saleItemsFound.RefundStatus = refundStatus;

            if(refundStatus == RefundStatus.Refunded)
            {
                _serviceWrapper.CouponCustomerService.CreateCustomerRefundCoupon(new CouponDTO
                {
                    CouponType = CouponType.Refund,
                    HasValidity = false,
                    Validity = DateTime.Now,
                    Name = $"Reembolso: {DateTime.Now.ToString("dd/MM/yyyy")}",
                    Value = saleItemsFound.UnitValue * saleItemsFound.Quantity
                },
                new CouponCustomerDTO
                {
                    CustomerId = saleItemsFound.Sale.CustomerId,
                    ValueRemaining = saleItemsFound.UnitValue * saleItemsFound.Quantity
                }
                );
            }

            _repository.Save();
        }

        public void ChangeSaleStatus(Guid id, SaleStatus status)
        {
            var saleFound = _repository.SaleRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            saleFound.SaleStatus = status;

            _repository.SaleRepository.Update(saleFound);
            _repository.Save();
        }

        public void GenerateSale(SaleCreateDTO saleCreateDTO, Guid customerId)
        {
            var shoppingCart = _repository.ShoppingCartRepository.GetShoppingCart(saleCreateDTO.ShoppingCartId);

            var coupons = new List<CouponCustomer>();

            if(saleCreateDTO.CustomerCoupons is not null)
            {
                coupons = _repository.CouponCustomerRepository.GetCouponsFullInfo(saleCreateDTO.CustomerCoupons.Select(x => x.Id).ToList());
            }

            var shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCart);

            var totalSaleValue = shoppingCartDTO.ShoppingCartItems.Sum(x => x.Quantity * x.Product.Price);

            totalSaleValue -= saleCreateDTO.Shipping;



            var sale = new Sale(customerId, saleCreateDTO.AddressId, saleCreateDTO.Shipping);

            sale.SaleItems = new List<SaleItem>();

            foreach(var cartItem in shoppingCartDTO.ShoppingCartItems)
            {
                var item = new SaleItem(sale.Id, cartItem.ProductId, cartItem.Product.Price, cartItem.Quantity);

                _serviceWrapper.StockService.ConsumeStock(cartItem.ProductId, cartItem.Quantity);

                sale.SaleItems.Add(item);
            }

            if (saleCreateDTO.CustomerCoupons is not null)
            {
                sale.SaleCoupons = new List<SaleCoupon>();
                foreach (var couponSale in saleCreateDTO.CustomerCoupons)
                {
                    var coupon = new SaleCoupon(couponSale.Id, sale.Id, couponSale.Value);

                    totalSaleValue -= couponSale.Value;

                    //var couponFound = _repository.CouponCustomerRepository.FindByCondition(x => x.Id == couponSale.Id).FirstOrDefault();
                    var couponFound = coupons.Where(x => x.Id == couponSale.Id).FirstOrDefault();

                    if (couponFound != null)
                    {
                        couponFound.ValueRemaining -= couponSale.Value;

                        _repository.CouponCustomerRepository.Update(couponFound);
                    }

                    sale.SaleCoupons.Add(coupon);
                }
            }

            sale.SalePayments = new List<SalePayment>();

            foreach (var cardPay in saleCreateDTO.CreditCards)
            {
                var card = new SalePayment(cardPay.Id, sale.Id, cardPay.Value);

                sale.SalePayments.Add(card);
            }

            

            _repository.SaleRepository.Create(sale);
            _repository.Save();
        }

        public SaleDTO GetSale(Guid id)
        {
            var sale = _repository.SaleRepository.GetSaleFullInfo(id);

            return _mapper.Map<SaleDTO>(sale);
        }

        public List<SaleDTO> GetSales()
        {
            var sales = _repository.SaleRepository.GetAllDetail();

            return _mapper.Map<List<SaleDTO>>(sales).OrderBy(x => x.SaleDate).ToList();
        }

        public List<SaleDTO> GetSalesFromCustomer(Guid customerId)
        {
            var sales = _repository.SaleRepository.GetCustomerSales(customerId);

            return _mapper.Map<List<SaleDTO>>(sales);
        }

        public SaleSummary GetSaleSummary(bool isQuantity, DateTime? startDate, DateTime? endDate, string? productCode)
        {
            var sales = _repository.SaleItemRepository.GetSaleItemsFilter(startDate, endDate, productCode);

            var saleSummary = new SaleSummary();

            saleSummary.MonthlyProductValue = sales.GroupBy(x => x.ProductId).Select(prod => new ProductSummary
            {
                ProductName = prod.First().Product.Name,
                Values = prod.GroupBy(x => new {x.Sale.SaleDate.Month, x.Sale.SaleDate.Year}).Select(s => new Utilities.MonthlyData<decimal>
                {
                    Month = new DateTime(s.Key.Year, s.Key.Month, 1),
                    Data = s.Sum(x => isQuantity ? x.Quantity : (x.UnitValue * x.Quantity))
                }).ToList()
            }).ToList();

            if(startDate == null)
            {
                startDate = saleSummary.MonthlyProductValue.SelectMany(x => x.Values).Select(x => x.Month).Min();
            }

            if (endDate == null)
            {
                endDate = saleSummary.MonthlyProductValue.SelectMany(x => x.Values).Select(x => x.Month).Max();
            }


            var result = new List<DateTime>();

            if (startDate.HasValue && endDate.HasValue)
            {
                while (startDate < endDate)
                {
                    result.Add(startDate.Value);
                    startDate = startDate.Value.AddMonths(1);
                }

                result.OrderBy(x => x);
            }


            saleSummary.MonthlyProductValue.ForEach(prod =>
            {
                result.ForEach(month =>
                {
                    var tempDate = new DateTime(month.Year, month.Month, 1);

                    if(!prod.Values.Any(x => x.Month == tempDate))
                    {
                        prod.Values.Add(new Utilities.MonthlyData<decimal> { Month = tempDate, Data = 0 });
                    }
                });
            });
            

            saleSummary.Order();

            return saleSummary;
        }

        public void RequestRefundSaleItems(List<SaleItemSummaryDTO> saleItems, Guid customerId)
        {
            var saleItemsFound = _repository.SaleItemRepository.GetSaleItemsFromList(_mapper.Map<List<SaleItem>>(saleItems)).ToList();

            saleItemsFound.ForEach(x =>
            {
                x.RefundStatus = RefundStatus.Requested;
                x.Sale.SaleStatus = SaleStatus.RefundRequested;
            });

            _repository.Save();
        }
    }
}
