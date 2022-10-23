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

                    var couponFound = _repository.CouponCustomerRepository.FindByCondition(x => x.Id == couponSale.Id).FirstOrDefault();
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

        public void RequestRefundSaleItems(List<SaleItemSummaryDTO> saleItems, Guid customerId)
        {
            var saleItemsFound = _repository.SaleItemRepository.GetSaleItemsFromList(_mapper.Map<List<SaleItem>>(saleItems)).ToList();

            var saleFound = _repository.SaleRepository.FindByCondition(x => x.Id == saleItemsFound.First().SaleId).FirstOrDefault();

            saleItemsFound.ForEach(x =>
            {
                x.RefundStatus = RefundStatus.Requested;
            });

            saleFound.SaleStatus = SaleStatus.RefundRequested;

            _repository.SaleRepository.Update(saleFound);

            _repository.Save();
        }
    }
}
