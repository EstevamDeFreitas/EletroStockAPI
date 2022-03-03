using EletroStockAPI.Context.Models;
using EletroStockAPI.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface ICustomerAccountRepository : IRepositoryBase
    {
        public CustomerAccount? GetCustomerAccount(string customerId);
        public void CreateCustomerAccount(CustomerAccount customerAccount);
        public void UpdateCustomerAccount(CustomerAccount customerAccount);
    }
}
