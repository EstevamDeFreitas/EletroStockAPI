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
        private ICustomerRepository _customerRepository;
        public RepositoryWrapper(EletroStockContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository is null)
                {
                    _customerRepository = new CustomerRepository(_dbContext);
                }
                return _customerRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
