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
        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repository));
            _addressService = new Lazy<IAddressService>(() => new AddressService(repository));
            _cardFlagService = new Lazy<ICardFlagService>(() => new CardFlagService(repository));
            _creditCardService = new Lazy<ICreditCardService>(() => new CreditCardService(repository));
            _inactiveCategoryService = new Lazy<IInactiveCategoryService>(() => new InactiveCategoryService(repository, mapper));
        }
        public ICustomerService CustomerService => _customerService.Value;

        public IAddressService AddressService => _addressService.Value;

        public ICardFlagService CardFlagService => _cardFlagService.Value;

        public ICreditCardService CardCreditCardService => _creditCardService.Value;

        public IInactiveCategoryService InactiveCategoryService => _inactiveCategoryService.Value;
    }
}
