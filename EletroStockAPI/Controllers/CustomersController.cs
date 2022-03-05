using AutoMapper;
using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;
using EletroStockAPI.Models.Shared;
using EletroStockAPI.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAccountRepository _customerAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomersController(IMapper mapper, ICustomerAccountRepository customerAccountRepository, ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _customerAccountRepository = customerAccountRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCustomer(string id)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(id);

                if (customer == null)
                {
                    return NotFound(new MessageBase<object>
                    {
                        Message = Message.NotFound
                    });
                }

                var customerModel = _mapper.Map<CustomerModel>(customer);

                return Ok(new MessageBase<CustomerModel>
                {
                    Message = Message.Success,
                    Result = customerModel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object>
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerCreateModel customer)
        {
            try
            {
                //TODO create a customer and address model validation

                var customerEntity = _mapper.Map<Customer>(customer);
                customerEntity.Id = EntityHelper.GenerateGuid();
                customerEntity.Status = Status.Active;
                customerEntity.BirthDate = EntityHelper.ConvertDatetimeToUTC(customerEntity.BirthDate);
                var status = _customerRepository.CreateCustomer(customerEntity);

                if (!status)
                {
                    return BadRequest(new MessageBase<object> { Message = Message.NotFound });
                }

                var addressEntity = _mapper.Map<Address>(customer.AddressModel);
                addressEntity.Id = EntityHelper.GenerateGuid();
                addressEntity.CustomerId = customerEntity.Id;
                _addressRepository.AddCustomerAddress(addressEntity);



                return Ok(new MessageBase<object>
                {
                    Message = Message.Success
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageBase<object>
                {
                    Message = ex.Message
                });
            }
        }
    }
}
