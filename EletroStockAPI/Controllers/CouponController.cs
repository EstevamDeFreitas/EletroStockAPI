using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public CouponController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetCoupons()
        {
            try
            {
                var coupons = _serviceWrapper.CouponCustomerService.GetCoupons();

                return Ok(new Response<List<CouponDTO>>
                {
                    Data = coupons,
                    Message = "Coupons Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet("customer")]
        [Authorize]
        public IActionResult GetCustomerCoupons()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                var coupons = _serviceWrapper.CouponCustomerService.GetCustomerCoupons(user);

                return Ok(new Response<List<CouponCustomerDTO>>
                {
                    Data = coupons,
                    Message = "Customer Coupons Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCoupon([FromBody] CouponDTO coupon)
        {
            try
            {
                _serviceWrapper.CouponCustomerService.CreateCoupon(coupon);

                return Ok(new Response<object>
                {
                    Message = "Coupon Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCoupon([FromBody] CouponDTO coupon)
        {
            try
            {
                _serviceWrapper.CouponCustomerService.UpdateCoupon(coupon);

                return Ok(new Response<object>
                {
                    Message = "Coupon Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(Guid couponId)
        {
            try
            {
                _serviceWrapper.CouponCustomerService.DeleteCoupon(couponId);

                return Ok(new Response<object>
                {
                    Message = "Coupon Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        
        [HttpPost("give")]
        public IActionResult UpdateCoupon([FromQuery] Guid customerId, [FromQuery] Guid couponId)
        {
            try
            {
                _serviceWrapper.CouponCustomerService.SendCouponToCustomer(couponId, customerId);

                return Ok(new Response<object>
                {
                    Message = "Coupon Send"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
