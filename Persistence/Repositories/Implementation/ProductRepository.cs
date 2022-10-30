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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public Product? GetProductFullInfo(Guid id)
        {
            return DbContext.Products.Include(x => x.PriceGroup)
                                        .Include(x => x.ProductImages)
                                        .Include(x => x.ProductCategories)
                                            .ThenInclude(x => x.Category)
                                        .Include(x => x.InactiveReason)
                                            .ThenInclude(x => x.InactiveCategory)
                                        .Include(x => x.Stocks)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetProductsFullInfo()
        {
            return DbContext.Products.Include(x => x.PriceGroup)
                                        .Include(x => x.ProductImages)
                                        .Include(x => x.ProductCategories)
                                            .ThenInclude(x => x.Category)
                                        .Include(x => x.InactiveReason)
                                            .ThenInclude(x => x.InactiveCategory)
                                        .Include(x => x.Stocks)
                                        .Where(x => (x.InactiveReason == null || x.InactiveReason.InactiveCategory.Active))
                                        .ToList();
        }
    }
}
