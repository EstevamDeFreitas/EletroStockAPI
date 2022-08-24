using Domain.Entities;
using Persistence.Database;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class CreditCardRepository : RepositoryBase<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }
    }
}
