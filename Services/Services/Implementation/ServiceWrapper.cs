using AutoMapper;
using Persistence.Repositories.Interfaces;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IAddressService> _addressService;
        private readonly Lazy<ICardFlagService> _cardFlagService;
        private readonly Lazy<ICreditCardService> _creditCardService;
        private readonly Lazy<IInactiveCategoryService> _inactiveCategoryService;
        private readonly Lazy<IInactiveReasonService> _inactiveReasonService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IPriceGroupService> _priceGroupService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IStockService> _stockService;
        private readonly Lazy<IShoppingCartService> _shoppingCartService;
        private readonly Lazy<ISaleService> _saleService;
        private readonly Lazy<ICouponCustomerService> _couponCustomerService;
        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repository));
            _addressService = new Lazy<IAddressService>(() => new AddressService(repository));
            _cardFlagService = new Lazy<ICardFlagService>(() => new CardFlagService(repository));
            _creditCardService = new Lazy<ICreditCardService>(() => new CreditCardService(repository));
            _inactiveCategoryService = new Lazy<IInactiveCategoryService>(() => new InactiveCategoryService(repository, mapper));
            _inactiveReasonService = new Lazy<IInactiveReasonService>(() => new InactiveReasonService(repository, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, mapper));
            _priceGroupService = new Lazy<IPriceGroupService>(() => new PriceGroupService(repository, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repository, mapper));
            _stockService = new Lazy<IStockService>(() => new StockService(repository, mapper));
            _shoppingCartService = new Lazy<IShoppingCartService>(() => new ShoppingCartService(repository, mapper));
            _saleService = new Lazy<ISaleService>(() => new SaleService(repository, mapper, this));
            _couponCustomerService = new Lazy<ICouponCustomerService>(() => new CouponCustomerService(repository, mapper));
        }
        public ICustomerService CustomerService => _customerService.Value;

        public IAddressService AddressService => _addressService.Value;

        public ICardFlagService CardFlagService => _cardFlagService.Value;

        public ICreditCardService CardCreditCardService => _creditCardService.Value;

        public IInactiveCategoryService InactiveCategoryService => _inactiveCategoryService.Value;

        public IInactiveReasonService InactiveReasonService => _inactiveReasonService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IPriceGroupService PriceGroupService => _priceGroupService.Value;
        public IProductService ProductService => _productService.Value;
        public IStockService StockService => _stockService.Value;

        public IShoppingCartService ShoppingCartService => _shoppingCartService.Value;

        public ISaleService SaleService => _saleService.Value;

        public ICouponCustomerService CouponCustomerService => _couponCustomerService.Value;
    }
}
