using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public CategoryController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _serviceWrapper.CategoryService.GetCategories();

                return Ok(new Response<List<CategoryDTO>>
                {
                    Message = "Categories Found",
                    Data = categories
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategory(Guid id)
        {
            try
            {
                var category = _serviceWrapper.CategoryService.GetCategory(id);

                return Ok(new Response<CategoryDTO>
                {
                    Message = "Category Found",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryDTO category)
        {
            try
            {
                _serviceWrapper.CategoryService.CreateCategory(category);

                return Ok(new Response<object>
                {
                    Message = "Category Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoryDTO category)
        {
            try
            {
                _serviceWrapper.CategoryService.UpdateCategory(category);

                return Ok(new Response<object>
                {
                    Message = "Category Updated"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(Guid id)
        {
            try
            {
                _serviceWrapper.CategoryService.DeleteCategory(id);

                return Ok(new Response<CategoryDTO>
                {
                    Message = "Category Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
