using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                context.Add(customer);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                context.Remove(customer);
                EndTransaction(true);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Customer? GetCustomer(string customerId)
        {
            return context.Customers.Find(customerId);
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                context.Update(customer);
                EndTransaction(true);
                return true;
            }
            catch(Exception ex)
            {
                return true;
            }
        }
    }
}
