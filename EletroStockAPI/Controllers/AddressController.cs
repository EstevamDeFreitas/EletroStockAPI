using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController
    {
        private readonly IServiceWrapper _services;
        public AddressController(IServiceWrapper services)
        {
            _services = services;
        }


    }
}
