using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_product_categories")]
    public class ProductCategory : EntityBase
    {
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
