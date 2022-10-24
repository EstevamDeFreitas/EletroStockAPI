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
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public List<Sale> GetAllDetail()
        {
            return DbContext.Sales.Include(x => x.Customer).ToList();
        }

        public List<Sale> GetCustomerSales(Guid customerId)
        {
            return DbContext.Sales.Include(x => x.SaleCoupons)
                                    .ThenInclude(x => x.CouponCustomer)
                                        .ThenInclude(x => x.Coupon)
                                .Include(x => x.SalePayments)
                                    .ThenInclude(x => x.CreditCard)
                                .Include(x => x.SaleItems)
                                    .ThenInclude(x => x.Product)
                                .Include(x => x.Customer)
                                .Where(x => x.CustomerId == customerId).ToList();
        }

        public Sale? GetSaleFullInfo(Guid id)
        {
            return DbContext.Sales.Include(x => x.SaleCoupons)
                                    .ThenInclude(x => x.CouponCustomer)
                                        .ThenInclude(x => x.Coupon)
                                .Include(x => x.SalePayments)
                                    .ThenInclude(x => x.CreditCard)
                                .Include(x => x.SaleItems)
                                    .ThenInclude(x => x.Product)
                                .Include(x => x.Customer)
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
        }
    }
}
