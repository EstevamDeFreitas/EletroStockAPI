using Microsoft.AspNetCore.Mvc;
using Services.DTO;
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

        [HttpGet]
        public IActionResult GetCustomersList()
        {
            try
            {
                var customers = _services.CustomerService.GetCustomers();

                return Ok(customers);
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

        [Route("{email}")]
        [HttpGet]
        public IActionResult GetCustomer(string email)
        {
            try
            {
                var customer = _services.CustomerService.GetCustomer(email);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
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
    }
}
