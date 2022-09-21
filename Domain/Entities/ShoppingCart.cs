using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_shopping_carts")]
    public class ShoppingCart : EntityBase
    {
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Required]
        [Column("dt_cart_validity")]
        public DateTime CartValidity { get; set; }

        public Customer Customer { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
