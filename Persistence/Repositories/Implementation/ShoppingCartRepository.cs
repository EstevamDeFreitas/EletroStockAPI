using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(EletroStockContext dbContext) : base(dbContext)
        {
        }

        public ShoppingCart? GetCustomerShoppingCart(Guid customerId)
        {
            return DbContext.ShoppingCarts.Include(x => x.ShoppingCartItems)
                                                .ThenInclude(x => x.Product)
                                                    .ThenInclude(x => x.Stocks)
                                            .Include(x => x.ShoppingCartItems)
                                                .ThenInclude(x => x.Product)
                                                    .ThenInclude(x => x.PriceGroup)
                                            .Where(x => x.CustomerId == customerId && x.CartValidity >= DateTime.Now).AsNoTracking().FirstOrDefault();
        }

        public ShoppingCart? GetShoppingCart(Guid id)
        {
            return DbContext.ShoppingCarts.Include(x => x.ShoppingCartItems)
                                                .ThenInclude(x => x.Product)
                                                    .ThenInclude(x => x.Stocks)
                                            .Include(x => x.ShoppingCartItems)
                                                .ThenInclude(x => x.Product)
                                                    .ThenInclude(x => x.PriceGroup)
                                            .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }
    }
}
