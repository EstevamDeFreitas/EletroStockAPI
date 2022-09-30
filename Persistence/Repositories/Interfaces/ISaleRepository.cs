using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        Sale? GetSaleFullInfo(Guid id);
        List<Sale> GetAllDetail();
        List<Sale> GetCustomerSales(Guid customerId);
    }
}
