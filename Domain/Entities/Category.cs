using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_categories")]
    public class Category : EntityBase
    {
        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
