using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_price_groups")]
    public class PriceGroup : EntityBase
    {
        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column("profit_margin")]
        public decimal ProfitMargin { get; set; }

        public List<Product> Products { get; set; }
    }
}
