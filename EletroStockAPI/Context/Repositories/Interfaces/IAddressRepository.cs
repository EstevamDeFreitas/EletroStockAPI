using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface IAddressRepository : IRepositoryBase
    {
        public List<Address> GetCustomerAddresses(string customerId);
        public bool AddCustomerAddress(Address address);
        public bool UpdateCustomerAddress(Address address);
        public bool DeleteCustomerAddress(Address address);
    }
}
