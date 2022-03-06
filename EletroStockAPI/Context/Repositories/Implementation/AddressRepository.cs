using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public bool AddCustomerAddress(Address address)
        {
            try
            {
                context.Addresses.Add(address);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCustomerAddress(Address address)
        {
            try
            {
                context.Remove(address);
                EndTransaction(true);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Address? GetAddress(string id)
        {
            return context.Addresses.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public List<Address> GetCustomerAddresses(string customerId)
        {
            return context.Addresses.Where(x => x.CustomerId == customerId).ToList();
        }

        public bool UpdateCustomerAddress(Address address)
        {
            try
            {
                context.Addresses.Update(address);
                EndTransaction(true);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
