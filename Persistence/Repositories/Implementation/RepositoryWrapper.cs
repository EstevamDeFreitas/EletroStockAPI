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
        public RepositoryWrapper(EletroStockContext dbContext)
        {
            _dbContext = dbContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
        }

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
