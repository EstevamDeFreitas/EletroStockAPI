using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ShoppingCartItemDTO
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public ProductDTO? Product { get; set; }
    }

    public class ShoppingCartAddDTO
    {
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}
