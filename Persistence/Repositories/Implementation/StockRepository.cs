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
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public List<Product> GetProductsStocks()
        {
            return DbContext.Products.Include(x => x.Stocks).ToList();
        }
    }
}
