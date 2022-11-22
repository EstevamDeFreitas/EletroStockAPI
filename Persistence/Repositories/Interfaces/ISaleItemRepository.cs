using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface ISaleItemRepository : IRepositoryBase<SaleItem>
    {
        public IEnumerable<SaleItem> GetSaleItemsFromList(List<SaleItem> saleItems);
        public IEnumerable<SaleItem> GetSaleItemsFilter(DateTime? startDate, DateTime? endDate, string? productCode);
    }
}
