using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InactiveCategoryController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public InactiveCategoryController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost]
        public IActionResult CreateInactiveCategory([FromBody]InactiveCategoryDTO inactiveCategory)
        {
            try
            {
                _serviceWrapper.InactiveCategoryService.CreateInactiveCategory(inactiveCategory);

                return Ok(new Response<object>
                {
                    Message = "Inactive Category Created"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetInactiveCategories()
        {
            try
            {
               var inactiveCategories = _serviceWrapper.InactiveCategoryService.GetInactiveCategories();

                return Ok(new Response<List<InactiveCategoryDTO>>
                {
                    Data = inactiveCategories,
                    Message = "Inactive Categories Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetInactiveCategory(Guid id)
        {
            try
            {
                var inactiveCategory = _serviceWrapper.InactiveCategoryService.GetInactiveCategory(id);

                return Ok(new Response<InactiveCategoryDTO>
                {
                    Data = inactiveCategory,
                    Message = "Inactive Category Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateInactiveCategory([FromBody] InactiveCategoryDTO inactiveCategory)
        {
            try
            {
                _serviceWrapper.InactiveCategoryService.UpdateInactiveCategory(inactiveCategory);

                return Ok(new Response<object>
                {
                    Message = "Inactive Category Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteInactiveCategory(Guid id)
        {
            try
            {
                _serviceWrapper.InactiveCategoryService.DeleteInactiveCategory(id);

                return Ok(new Response<object>
                {
                    Message = "Inactive Category Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
