using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CartValidity { get; set; }

        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
    }
}
