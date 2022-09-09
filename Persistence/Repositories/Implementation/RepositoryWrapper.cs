﻿using Persistence.Database;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EletroStockContext _dbContext;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<ICardFlagRepository> _cardFlagRepository;
        private readonly Lazy<ICreditCardRepository> _creditCardRepository;
        private readonly Lazy<ICustomerAccountRepository> _customerAccountRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IInactiveCategoryRepository> _inactiveCategoryRepository;
        private readonly Lazy<IInactiveReasonRepository> _inactiveReasonRepository;
        private readonly Lazy<IPriceGroupRepository> _priceGroupRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        public RepositoryWrapper(EletroStockContext dbContext)
        {
            _dbContext = dbContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(dbContext));
            _cardFlagRepository = new Lazy<ICardFlagRepository>(() => new CardFlagRepository(dbContext));
            _creditCardRepository = new Lazy<ICreditCardRepository>(() => new CreditCardRepository(dbContext));
            _customerAccountRepository = new Lazy<ICustomerAccountRepository>(() => new CustomerAccountRepository(dbContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
            _inactiveCategoryRepository = new Lazy<IInactiveCategoryRepository>(() => new InactiveCategoryRepository(dbContext));
            _inactiveReasonRepository = new Lazy<IInactiveReasonRepository>(() => new InactiveReasonRepository(dbContext));
            _priceGroupRepository = new Lazy<IPriceGroupRepository>(() => new PriceGroupRepository(dbContext));
            _productImageRepository = new Lazy<IProductImageRepository>(() => new ProductImageRepository(dbContext));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(dbContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
        }

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IAddressRepository AddressRepository => _addressRepository.Value;

        public ICreditCardRepository CreditCardRepository => _creditCardRepository.Value;

        public ICardFlagRepository CardFlagRepository => _cardFlagRepository.Value;

        public ICustomerAccountRepository CustomerAccountRepository => _customerAccountRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IInactiveCategoryRepository InactiveCategoryRepository => _inactiveCategoryRepository.Value;

        public IInactiveReasonRepository InactiveReasonRepository => _inactiveReasonRepository.Value;

        public IPriceGroupRepository PriceGroupRepository => _priceGroupRepository.Value;

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;

        public IProductImageRepository ProductImageRepository => _productImageRepository.Value;

        public IProductRepository ProductRepository => _productRepository.Value;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
