using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceGroupController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public PriceGroupController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetPriceGroups()
        {
            try
            {
                var priceGroups = _serviceWrapper.PriceGroupService.GetPriceGroups();

                return Ok(new Response<List<PriceGroupDTO>>
                {
                    Message = "Price Group Found",
                    Data = priceGroups
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPriceGroup(Guid id)
        {
            try
            {
                var priceGroup = _serviceWrapper.PriceGroupService.GetPriceGroup(id);

                return Ok(new Response<PriceGroupDTO>
                {
                    Message = "Price Group Found",
                    Data = priceGroup
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreatePriceGroup([FromBody]PriceGroupDTO priceGroup)
        {
            try
            {
               _serviceWrapper.PriceGroupService.CreatePriceGroup(priceGroup);

                return Ok(new Response<object>
                {
                    Message = "Price Group Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdatePriceGroup([FromBody] PriceGroupDTO priceGroup)
        {
            try
            {
                _serviceWrapper.PriceGroupService.UpdatePriceGroup(priceGroup);

                return Ok(new Response<object>
                {
                    Message = "Price Group Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePriceGroup(Guid id)
        {
            try
            {
                _serviceWrapper.PriceGroupService.DeletePriceGroup(id);

                return Ok(new Response<PriceGroupDTO>
                {
                    Message = "Price Group Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
