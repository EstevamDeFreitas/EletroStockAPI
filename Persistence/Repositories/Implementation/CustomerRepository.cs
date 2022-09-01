using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public Customer? GetCustomer(Guid customerId)
        {
            return DbContext.Customers.Include(x => x.CustomerAccount)
                                        .Include(x => x.CreditCards)
                                        .Include(x => x.Addresses)
                                        .Where(x => x.Id == customerId)
                                        .FirstOrDefault();
        }
    }
}
