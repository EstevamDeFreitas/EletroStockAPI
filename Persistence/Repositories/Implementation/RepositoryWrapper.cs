using Persistence.Database;
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
        public RepositoryWrapper(EletroStockContext dbContext)
        {
            _dbContext = dbContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(dbContext));
            _cardFlagRepository = new Lazy<ICardFlagRepository>(() => new CardFlagRepository(dbContext));
            _creditCardRepository = new Lazy<ICreditCardRepository>(() => new CreditCardRepository(dbContext));
            _customerAccountRepository = new Lazy<ICustomerAccountRepository>(() => new CustomerAccountRepository(dbContext));
        }

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IAddressRepository AddressRepository => _addressRepository.Value;

        public ICreditCardRepository CreditCardRepository => _creditCardRepository.Value;

        public ICardFlagRepository CardFlagRepository => _cardFlagRepository.Value;

        public ICustomerAccountRepository CustomerAccountRepository => _customerAccountRepository.Value;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
