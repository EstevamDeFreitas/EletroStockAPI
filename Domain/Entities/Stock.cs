using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_stocks")]
    public class Stock : EntityBase
    {
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("source_name")]
        public string SourceName { get; set; }
        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }
        [Required]
        [Column("value")]
        public decimal Value { get; set; }
        public Product Product { get; set; }
    }
}
