using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase
    {
        public Customer? GetCustomer(string customerId);
        public List<Customer> GetCustomers();
        public bool DeleteCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool CreateCustomer(Customer customer);
    }
}
