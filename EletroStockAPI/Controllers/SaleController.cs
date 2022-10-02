﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public SaleController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCustomerSales()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                var sales = _serviceWrapper.SaleService.GetSalesFromCustomer(user);

                return Ok(new Response<List<SaleDTO>>
                {
                    Data = sales,
                    Message = "Sales Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCustomerSale([FromBody]SaleCreateDTO saleCreate)
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                _serviceWrapper.SaleService.GenerateSale(saleCreate, user);

                return Ok(new Response<object>
                {
                    Message = "Sale Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}