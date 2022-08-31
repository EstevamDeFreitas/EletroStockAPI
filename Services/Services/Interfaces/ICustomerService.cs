using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomer(string email);
        List<CustomerDTO> GetCustomers();
        Guid LoginCustomer(string email, string password);
        void CreateCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(string email);
        void ChangePassword(CustomerChangePasswordDTO customerChangePassword);
    }
}
