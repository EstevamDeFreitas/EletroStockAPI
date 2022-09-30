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

        public void ChangeSaleStatus(Guid id, SaleStatus status)
        {
            throw new NotImplementedException();
        }

        public void GenerateSale(SaleCreateDTO saleCreateDTO, Guid customerId)
        {
            var shoppingCart = _repository.ShoppingCartRepository.GetShoppingCart(saleCreateDTO.ShoppingCartId);

            var coupons = new List<CouponCustomer>();

            if(saleCreateDTO.CustomerCouponsIds is not null)
            {
                coupons = _repository.CouponCustomerRepository.GetCouponsFullInfo(saleCreateDTO.CustomerCouponsIds.Select(x => x.Id).ToList());
            }

            var shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCart);

            var totalSaleValue = shoppingCartDTO.ShoppingCartItems.Sum(x => x.Quantity * x.Product.Price);



            var sale = new Sale(customerId, saleCreateDTO.AddressId, saleCreateDTO.Shipping);

            var saleItems = new List<SaleItem>();

            foreach(var cartItem in shoppingCartDTO.ShoppingCartItems)
            {
                var item = new SaleItem(sale.Id, cartItem.ProductId, cartItem.Product.Price, cartItem.Quantity);

                _serviceWrapper.StockService.ConsumeStock(cartItem.ProductId, cartItem.Quantity);

                sale.SaleItems.Add(item);
            }

            foreach (var cardPay in saleCreateDTO.CreditCards)
            {
                var card = new SalePayment(cardPay.Id, sale.Id, cardPay.Value);

                sale.SalePayments.Add(card);
            }

            if(saleCreateDTO.CustomerCouponsIds is not null)
            {
                foreach (var couponSale in saleCreateDTO.CustomerCouponsIds)
                {
                    var coupon = new SaleCoupon(couponSale.Id, sale.Id, couponSale.Value);

                    sale.SaleCoupons.Add(coupon);
                }
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

            return _mapper.Map<List<SaleDTO>>(sales);
        }

        public List<SaleDTO> GetSalesFromCustomer(Guid customerId)
        {
            var sales = _repository.SaleRepository.GetCustomerSales(customerId);

            return _mapper.Map<List<SaleDTO>>(sales);
        }
    }
}
