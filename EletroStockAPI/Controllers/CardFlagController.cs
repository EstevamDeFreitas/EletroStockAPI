using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardFlagController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public CardFlagController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetAllCardFlags()
        {
            try
            {
                var flags = _serviceWrapper.CardFlagService.GetCardFlags();

                return Ok(new Response<List<CardFlagDTO>>
                {
                    Data = flags,
                    Message = "Card Flags Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCardFlag([FromBody] string cardName)
        {
            try
            {
                _serviceWrapper.CardFlagService.CreateCardFlag(cardName);

                return Ok(new Response<object>
                {
                    Message = "Card Flags Created"
                });
            }
            catch (ValidationFailed validation)
            {
                return BadRequest(new Response<List<FieldError>>
                {
                    Data = validation.Errors,
                    Message = validation.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{cardFlagId}")]
        [HttpGet]
        public IActionResult GetCardFlag(Guid cardFlagId)
        {
            try
            {
                var cardFlag = _serviceWrapper.CardFlagService.GetCardFlag(cardFlagId);

                return Ok(new Response<CardFlagDTO>
                {
                    Data = cardFlag,
                    Message = "Card Flag Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCardFlag(CardFlagDTO cardFlag)
        {
            try
            {
                _serviceWrapper.CardFlagService.UpdateCardFlag(cardFlag);

                return Ok(new Response<object>
                {
                    Message = "Card Flag Updated"
                });
            }
            catch (ValidationFailed validation)
            {
                return BadRequest(new Response<List<FieldError>>
                {
                    Data = validation.Errors,
                    Message = validation.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [Route("{cardFlagId}")]
        [HttpDelete]
        public IActionResult DeleteCardFlag(Guid cardFlagId)
        {
            try
            {
                _serviceWrapper.CardFlagService.DeleteCardFlag(cardFlagId);

                return Ok(new Response<object>
                {
                    Message = "Card Flag Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
