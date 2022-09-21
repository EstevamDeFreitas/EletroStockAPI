using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_shopping_cart_items")]
    public class ShoppingCartItem
    {
        [Key]
        [Required]
        [Column("shopping_cart_id")]
        public Guid ShoppingCartId { get; set; }
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("quantity")]
        public uint Quantity { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
    }
}
