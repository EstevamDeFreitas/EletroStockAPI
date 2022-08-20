using Persistence.Repositories.Interfaces;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IAddressService> _addressService;
        public ServiceWrapper(IRepositoryWrapper repository)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repository));
            _addressService = new Lazy<IAddressService>(() => new AddressService(repository));
        }
        public ICustomerService CustomerService => _customerService.Value;

        public IAddressService AddressService => throw new NotImplementedException();
    }
}
