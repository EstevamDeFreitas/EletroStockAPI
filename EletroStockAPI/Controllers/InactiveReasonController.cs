using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InactiveReasonController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public InactiveReasonController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetInactiveReason(Guid id)
        {
            try
            {
                var inactiveReason = _serviceWrapper.InactiveReasonService.GetInactiveReason(id);

                return Ok(new Response<InactiveReasonDTO>
                {
                    Message = "Inactive Reason Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateInactiveReason([FromBody] InactiveReasonDTO inactiveReason)
        {
            try
            {
                 _serviceWrapper.InactiveReasonService.CreateInactiveReason(inactiveReason);

                return Ok(new Response<object>
                {
                    Message = "Inactive Reason Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateInactiveReason([FromBody] InactiveReasonDTO inactiveReason)
        {
            try
            {
                _serviceWrapper.InactiveReasonService.UpdateInactiveReason(inactiveReason);

                return Ok(new Response<object>
                {
                    Message = "Inactive Reason Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteInactiveReason(Guid id)
        {
            try
            {
                _serviceWrapper.InactiveReasonService.DeleteInactiveReason(id);

                return Ok(new Response<object>
                {
                    Message = "Inactive Reason Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
