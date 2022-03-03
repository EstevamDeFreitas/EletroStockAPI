using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class CustomerAccountRepository : RepositoryBase, ICustomerAccountRepository
    {
        public CustomerAccountRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateCustomerAccount(CustomerAccount customerAccount)
        {
            context.CustomerAccounts.Add(customerAccount);
            EndTransaction(true);
        }

        public CustomerAccount? GetCustomerAccount(string customerId)
        {
            return context.CustomerAccounts.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }

        public void UpdateCustomerAccount(CustomerAccount customerAccount)
        {
            context.CustomerAccounts.Update(customerAccount);
            EndTransaction(true);
        }
    }
}
