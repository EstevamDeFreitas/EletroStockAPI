using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public CustomerController(IServiceWrapper services)
        {
            _services = services;
        }

        [Route("all")]
        [HttpGet]
        [Authorize]
        public IActionResult GetCustomersList()
        {
            try
            {
                var customers = _services.CustomerService.GetCustomers();

                return Ok(new Response<List<CustomerDTO>>
                {
                    Message = "Customers Found",
                    Data = customers
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CustomerDTO customer)
        {
            try
            {
                _services.CustomerService.CreateCustomer(customer);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCustomer()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);
                var customer = _services.CustomerService.GetCustomer(user);

                return Ok(new Response<CustomerDTO>
                {
                    Data = customer,
                    Message = "Customer Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                _services.CustomerService.UpdateCustomer(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{email}")]
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteCustomer(string email)
        {
            try
            {
                _services.CustomerService.DeleteCustomer(email);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("password")]
        [HttpPut]
        [Authorize]
        public IActionResult ChangePassword(CustomerChangePasswordDTO customerChangePassword)
        {
            try
            {
                _services.CustomerService.ChangePassword(customerChangePassword);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("account")]
        [HttpPut]
        public IActionResult UpdateAccount(CustomerAccountDTO customerAccount)
        {
            try
            {
                _services.CustomerService.ChangeAccountSettings(customerAccount);

                return Ok(new Response<object> { Message = "Account Settings Changed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
