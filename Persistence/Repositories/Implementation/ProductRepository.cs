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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }
    }
}
