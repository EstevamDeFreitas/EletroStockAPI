using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CouponDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public CouponType CouponType { get; set; }
        public DateTime Validity { get; set; }
        public bool HasValidity { get; set; }
        public decimal Value { get; set; }
    }

    public class CouponCustomerDTO
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CouponId { get; set; }
        public decimal ValueRemaining { get; set; }

        public CouponDTO? Coupon { get; set; }
    }
}
