using AutoMapper;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;
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
        public IActionResult GetCustomerAddresses(string customerId)
        {
            try
            {
                var addresses = _addressRepository.GetCustomerAddresses(customerId);

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
    }
}
