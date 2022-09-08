using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_product_images")]
    public class ProductImage : EntityBase
    {
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }

        public Product Product { get; set; }
    }
}
