using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository CustomerRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICreditCardRepository CreditCardRepository { get; }
        ICardFlagRepository CardFlagRepository { get; }
        ICustomerAccountRepository CustomerAccountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IInactiveCategoryRepository InactiveCategoryRepository { get; }
        IInactiveReasonRepository InactiveReasonRepository { get; }
        IPriceGroupRepository PriceGroupRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductRepository ProductRepository { get; }
        IStockRepository StockRepository { get; }
        IShoppingCartItemRepository ShoppingCartItemRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        void Save();
    }
}
