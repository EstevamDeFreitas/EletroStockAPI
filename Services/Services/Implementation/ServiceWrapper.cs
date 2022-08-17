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
        public ServiceWrapper(IRepositoryWrapper repository)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService());
        }
        public ICustomerService CustomerService => _customerService.Value;
    }
}
