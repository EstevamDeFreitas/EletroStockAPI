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
    public class SaleItemRepository : RepositoryBase<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SaleItem> GetSaleItemsFromList(List<SaleItem> saleItems)
        {
            return DbContext.SaleItems.Include(x => x.Sale).AsEnumerable().Where(x => saleItems.AsEnumerable().Any(y => y.SaleId == x.SaleId && y.ProductId == x.ProductId));
        }
    }
}
