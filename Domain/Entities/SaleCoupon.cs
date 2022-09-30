using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_sale_coupons")]
    public class SaleCoupon
    {
        [Required]
        [Column("customer_coupon_id")]
        public Guid CouponCustomerId { get; set; }
        [Required]
        [Column("sale_id")]
        public Guid SaleId { get; set; }
        [Required]
        [Column("vl_discount")]
        public decimal DiscountValue { get; set; }

        public SaleCoupon() { }

        public SaleCoupon(Guid couponCustomerId, Guid saleId, decimal discountValue)
        {
            CouponCustomerId = couponCustomerId;
            SaleId = saleId;
            DiscountValue = discountValue;
        }

        public Sale Sale { get; set; }
        public CouponCustomer CouponCustomer { get; set; }
    }
}
