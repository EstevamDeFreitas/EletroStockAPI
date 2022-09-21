using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO GetShoppingCart(Guid customerId);
        void AddItem(ShoppingCartAddDTO item, Guid customerId);
        void RemoveItem(ShoppingCartItemDTO item);
        void UpdateItem(ShoppingCartItemDTO item);
        void DeleteShoppingCart(Guid id);
    }
}
