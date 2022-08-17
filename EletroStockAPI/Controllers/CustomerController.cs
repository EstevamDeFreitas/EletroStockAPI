using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;

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
        
        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CustomerDTO customer)
        {
            _services.CustomerService.CreateCustomer(customer);
            return Ok();
        }
    }
}
