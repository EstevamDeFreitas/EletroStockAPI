using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IAddressService
    {
        List<AddressDTO> GetCustomerAddresses(Guid customerId);
        AddressDTO GetAddress(Guid addressId);
        void CreateAddress(AddressDTO addressDTO);
        void UpdateAddress(AddressDTO addressDTO);
        void DeleteAddress(Guid addressId);
    }
}
