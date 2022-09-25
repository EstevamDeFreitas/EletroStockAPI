using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SaleCouponDTO
    {
        public Guid CouponCustomerId { get; set; }
        public Guid SaleId { get; set; }
        public decimal DiscountValue { get; set; }
    }
}
