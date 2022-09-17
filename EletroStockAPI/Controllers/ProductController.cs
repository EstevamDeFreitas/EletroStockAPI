using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ProductController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _serviceWrapper.ProductService.GetProducts();

                return Ok(new Response<List<ProductDTO>>
                {
                    Data = products,
                    Message = "Products Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            try
            {
                var product = _serviceWrapper.ProductService.GetProduct(id);

                return Ok(new Response<ProductDTO>
                {
                    Data = product,
                    Message = "Product Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO product)
        {
            try
            {
                _serviceWrapper.ProductService.CreateProduct(product);

                return Ok(new Response<object>
                {
                    Message = "Product Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDTO product)
        {
            try
            {
                _serviceWrapper.ProductService.UpdateProduct(product);

                return Ok(new Response<object>
                {
                    Message = "Product Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost("{id}/disable")]
        public IActionResult DisableProduct(Guid id, [FromBody] InactiveReasonDTO inactiveReason)
        {
            try
            {
                _serviceWrapper.ProductService.DisableProduct(id, inactiveReason);

                return Ok(new Response<object>
                {
                    Message = "Product Disabled"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
        
    }
}
