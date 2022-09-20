using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;
        public StockController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetStocks()
        {
            try
            {
                var stocks = _serviceWrapper.StockService.GetStocks();

                return Ok(new Response<List<StockDTO>>
                {
                    Data = stocks,
                    Message = "Stocks Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateStock(StockDTO stock)
        {
            try
            {
                _serviceWrapper.StockService.CreateStock(stock);

                return Ok(new Response<object>
                {
                    Message = "Stock Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        //[HttpPut]
        //public IActionResult UpdateStock(StockDTO stock)
        //{
        //    try
        //    {
        //        _serviceWrapper.StockService.UpdateStock(stock);

        //        return Ok(new Response<object>
        //        {
        //            Message = "Stock Created"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new Response<object> { Message = ex.Message });
        //    }
        //}

        [HttpGet("product")]
        public IActionResult GetStocksByProducts()
        {
            try
            {
                var products = _serviceWrapper.StockService.GetStockByProduct();

                return Ok(new Response<List<ProductStockDTO>>
                {
                    Data = products,
                    Message = "Products Stocks Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

    }
}
