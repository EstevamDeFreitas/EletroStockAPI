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
        private readonly ICreditCardRepository _creditCardRepository;

        public CustomersController(IMapper mapper, ICustomerAccountRepository customerAccountRepository, ICustomerRepository customerRepository, IAddressRepository addressRepository, ICreditCardRepository creditCardRepository)
        {
            _mapper = mapper;
            _customerAccountRepository = customerAccountRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _creditCardRepository = creditCardRepository;
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

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _customerRepository.GetCustomers();
                var customerModel = _mapper.Map<List<CustomerModel>>(customers);

                return Ok(new MessageBase<List<CustomerModel>> { Message = Message.Success, Result = customerModel });
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message});
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

                var customerAccountEntity = new CustomerAccount
                {
                    CustomerId = customerEntity.Id,
                    ChargeAddressId = addressEntity.Id,
                    DeliveryAddressId = addressEntity.Id,
                    Id = EntityHelper.GenerateGuid()
                };
                _customerAccountRepository.CreateCustomerAccount(customerAccountEntity);


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

        [HttpPut]
        public IActionResult EditCustomer([FromBody] CustomerModel customer)
        {
            try
            {
                var customerEntity = _mapper.Map<Customer>(customer);
                customerEntity.BirthDate = EntityHelper.ConvertDatetimeToUTC(customerEntity.BirthDate);
                _customerRepository.UpdateCustomer(customerEntity);

                return Ok(new MessageBase<object>
                {
                    Message = Message.Success
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message=ex.Message});
            }
        }

        [Route("{id}/account")]
        [HttpGet]
        public IActionResult GetCustomerAccount(string id)
        {
            try
            {
                var customerAccount = _customerAccountRepository.GetCustomerAccount(id);

                if(customerAccount == null)
                {
                    return NotFound(new MessageBase<object> { Message = Message.NotFound });
                }

                return Ok(new MessageBase<CustomerAccount> { Message = Message.Success, Result = customerAccount});
                
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message});
            }
        }

        [Route("{id}/account")]
        [HttpPost]
        public IActionResult EditCustomerAccount(string id, [FromQuery] string chargeAddressId = "", [FromQuery] string deliveryAddressId = "", [FromQuery] string defaultCardId = "")
        {
            try
            {
                var customerAccount = _customerAccountRepository.GetCustomerAccount(id);

                if(customerAccount == null)
                {
                    return NotFound(new MessageBase<object> { Message = Message.NotFound });
                }

                if(deliveryAddressId != "")
                {
                    var deliveryAddress = _addressRepository.GetAddress(deliveryAddressId);

                    if(deliveryAddress == null)
                    {
                        return NotFound(new MessageBase<object> { Message = AddressMessage.DeliveryNotFound });
                    }

                    customerAccount.DeliveryAddressId = deliveryAddressId;
                }

                if(chargeAddressId != "")
                {
                    var chargeAddress = _addressRepository.GetAddress(chargeAddressId);

                    if(chargeAddress == null)
                    {
                        return NotFound(new MessageBase<object> { Message = AddressMessage.ChargeNotFound});
                    }

                    customerAccount.ChargeAddressId = chargeAddressId;
                }

                if(defaultCardId != "")
                {
                    var defaultCard = _creditCardRepository.GetCredit(defaultCardId);

                    if(defaultCard == null)
                    {
                        return NotFound(new MessageBase<object> { Message= Message.NotFound });
                    }

                    customerAccount.CardId = defaultCardId;
                }

                _customerAccountRepository.UpdateCustomerAccount(customerAccount);

                return Ok(new MessageBase<object>{ Message = Message.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message=ex.Message});
            }
        }
    }
}
