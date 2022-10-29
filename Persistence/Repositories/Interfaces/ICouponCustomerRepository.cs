using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface ICouponCustomerRepository : IRepositoryBase<CouponCustomer>
    {
        List<CouponCustomer> GetCouponsFullInfo(List<Guid> customerCouponsIds);
        List<CouponCustomer> GetCustomerCoupons(Guid customerId);
    }
}
