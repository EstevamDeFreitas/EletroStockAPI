using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_coupons")]
    public class Coupon : EntityBase
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("coupon_type")]
        public CouponType CouponType { get; set; }
        [Required]
        [Column("dt_validity")]
        public DateTime Validity { get; set; }
        [Required]
        [Column("has_validity")]
        public bool HasValidity { get; set; }
        [Required]
        [Column("value")]
        public decimal Value { get; set; }
    }

    public enum CouponType
    {
        Percentage,
        Value
    }
}
