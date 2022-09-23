using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_customer_coupons")]
    public class CouponCustomer
    {
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Required]
        [Column("coupon_id")]
        public Guid CouponId { get; set; }
        [Required]
        [Column("value_remaining")]
        public decimal ValueRemaining { get; set; }

        public Customer Customer { get; set; }
        public Coupon Coupon { get; set; }
    }
}
