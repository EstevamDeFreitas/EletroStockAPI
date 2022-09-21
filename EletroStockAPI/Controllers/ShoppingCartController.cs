using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public ShoppingCartController(IServiceWrapper services)
        {
            _services = services;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCustomerShoppingCart()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                var shoppingCart = _services.ShoppingCartService.GetShoppingCart(user);

                return Ok(new Response<ShoppingCartDTO>
                {
                    Data = shoppingCart,
                    Message = "Shopping Cart Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddShoppingCartItem([FromBody] ShoppingCartAddDTO item)
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                _services.ShoppingCartService.AddItem(item, user);

                return Ok(new Response<object>
                {
                    Message = "Item Added"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpDelete("item")]
        [Authorize]
        public IActionResult RemoveShoppingCartItem([FromBody] ShoppingCartItemDTO item)
        {
            try
            {
                _services.ShoppingCartService.RemoveItem(item);

                return Ok(new Response<object>
                {
                    Message = "Item Removed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteShoppingCart(Guid id)
        {
            try
            {
                _services.ShoppingCartService.DeleteShoppingCart(id);

                return Ok(new Response<object>
                {
                    Message = "Shopping Cart Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateShoppingCartItem([FromBody] ShoppingCartItemDTO item)
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                _services.ShoppingCartService.UpdateItem(item);

                return Ok(new Response<object>
                {
                    Message = "Item Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
