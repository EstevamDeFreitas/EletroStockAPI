using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IServiceWrapper
    {
        ICustomerService CustomerService { get; }
        IAddressService AddressService { get; }
        ICardFlagService CardFlagService { get; }
        ICreditCardService CardCreditCardService { get; }
        IInactiveCategoryService InactiveCategoryService { get; }
        IInactiveReasonService InactiveReasonService { get; }
        ICategoryService CategoryService { get; }
        IPriceGroupService PriceGroupService { get; }
        IProductService ProductService { get; }
        IStockService StockService { get; }
        IShoppingCartService ShoppingCartService { get; }
        ISaleService SaleService { get; }
        ICouponCustomerService CouponCustomerService { get; }
    }
}
