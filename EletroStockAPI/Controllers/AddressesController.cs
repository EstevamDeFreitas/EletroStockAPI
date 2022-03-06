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
    public class AddressesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAccountRepository _customerAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public AddressesController(IMapper mapper, ICustomerAccountRepository customerAccountRepository, ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _customerAccountRepository = customerAccountRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        [Route("customer/{id}")]
        [HttpGet]
        public IActionResult GetCustomerAddresses(string id)
        {
            try
            {
                var addresses = _addressRepository.GetCustomerAddresses(id);

                var addressesModels = _mapper.Map<List<AddressModel>>(addresses);

                return Ok(new MessageBase<List<AddressModel>>
                {
                    Message = Message.Success,
                    Result = addressesModels
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message});
            }
        }

        [HttpPost]
        public IActionResult CreateAddress([FromBody] AddressModel address)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(address.CustomerId);

                if(customer == null)
                {
                    return NotFound(new MessageBase<object>
                    {
                        Message = "Customer not found",
                    });
                }

                //TODO add the address validation
                var addressEntity = _mapper.Map<Address>(address);
                addressEntity.Id = EntityHelper.GenerateGuid();
                _addressRepository.AddCustomerAddress(addressEntity);

                return Ok(new MessageBase<object> { Message = Message.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult EditAddress([FromBody] AddressModel address)
        {
            try
            {
                //TODO add address validation
                var addressEntity = _mapper.Map<Address>(address);
                var result = _addressRepository.UpdateCustomerAddress(addressEntity);

                return Ok(new MessageBase<bool>
                {
                    Message = Message.Success,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object>() { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteAddress(string id)
        {
            try
            {
                var addressEntity = _addressRepository.GetAddress(id);

                if(addressEntity == null)
                {
                    return NotFound(new MessageBase<object>
                    {
                        Message=Message.NotFound
                    });
                }

                var customerAccount = _customerAccountRepository.GetCustomerAccount(addressEntity.CustomerId);

                if(customerAccount != null)
                {
                    if(customerAccount.ChargeAddressId == id || customerAccount.DeliveryAddressId == id)
                    {
                        return BadRequest(new MessageBase<object>
                        {
                            Message = Message.ObjectInUse
                        });
                    }

                    _addressRepository.DeleteCustomerAddress(addressEntity);

                }

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
