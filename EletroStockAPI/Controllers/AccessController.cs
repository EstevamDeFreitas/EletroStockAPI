using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public AccessController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult LoginCustomer([FromBody] LoginDTO login)
        {
            try
            {
                var customer = _serviceWrapper.CustomerService.LoginCustomer(login.Email, login.Password);

                return Ok(new Response<Guid>
                {
                    Data = customer,
                    Message = "Customer Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
