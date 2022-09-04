using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public AddressController(IServiceWrapper services)
        {
            _services = services;
        }

        [Route("list")]
        [HttpGet]
        [Authorize]
        public IActionResult GetUserAddresses()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);
                var addressList = _services.AddressService.GetCustomerAddresses(user);

                return Ok(new Response<List<AddressDTO>>
                {
                    Data = addressList,
                    Message = "Addresses Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message});
            }
        }

        [Route("{addressId}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetAddress(Guid addressId)
        {
            try
            {
                var address = _services.AddressService.GetAddress(addressId);

                return Ok(new Response<AddressDTO>
                {
                    Data = address,
                    Message = "Address Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateAddress(AddressDTO address)
        {
            try
            {
                _services.AddressService.CreateAddress(address);

                return Ok(new Response<object> { Message = "Address Created" });
            }
            catch(ValidationFailed validation)
            {
                return BadRequest(new Response<List<FieldError>>
                {
                    Data = validation.Errors,
                    Message = validation.Message
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateAddress(AddressDTO address)
        {
            try
            {
                _services.AddressService.UpdateAddress(address);

                return Ok(new Response<object> { Message = "Address Updated" });
            }
            catch (ValidationFailed validation)
            {
                return BadRequest(new Response<List<FieldError>>
                {
                    Data = validation.Errors,
                    Message = validation.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{addressId}")]
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteAddress(Guid addressId)
        {
            try
            {
                _services.AddressService.DeleteAddress(addressId);

                return Ok(new Response<object> { Message = "Address Deleted" });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
