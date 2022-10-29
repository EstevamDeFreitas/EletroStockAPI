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
    public class CouponCustomerRepository : RepositoryBase<CouponCustomer>, ICouponCustomerRepository
    {
        public CouponCustomerRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public List<CouponCustomer> GetCouponsFullInfo(List<Guid> customerCouponsIds)
        {
            return DbContext.CouponCustomers.Include(x => x.Coupon).Where(x => customerCouponsIds.Contains(x.Id)).ToList();
        }

        public List<CouponCustomer> GetCustomerCoupons(Guid customerId)
        {
            return DbContext.CouponCustomers.Include(x => x.Coupon).Where(x => x.CustomerId == customerId && x.ValueRemaining > 0 && (x.Coupon.HasValidity? DateTime.Now < x.Coupon.Validity : true)).ToList();
        }
    }
}
