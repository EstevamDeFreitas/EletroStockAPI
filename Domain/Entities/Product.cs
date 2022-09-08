using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_products")]
    public class Product : EntityBase
    {
        [Required]
        [Column("code")]
        [StringLength(6)]
        public string Code { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column("price_group_id")]
        public Guid PriceGroupId { get; set; }
        [Required]
        [Column("inactive_reason_id")]
        public Guid InactiveReasonId { get; set; }

        public PriceGroup PriceGroup { get; set; }
        public InactiveReason InactiveReason { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
