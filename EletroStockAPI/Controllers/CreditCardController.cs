using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public CreditCardController(IServiceWrapper services)
        {
            _services = services;
        }

        [Route("{creditCardId}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetCreditCard(Guid creditCardId)
        {
            try
            {
                var creditCard = _services.CardCreditCardService.GetCreditCard(creditCardId);

                return Ok(new Response<CreditCardDTO>
                {
                    Data = creditCard,
                    Message = "Credit Card Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCustomerCreditCards()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);
                var creditCards = _services.CardCreditCardService.GetCustomerCreditCards(user);

                return Ok(new Response<List<CreditCardDTO>>
                {
                    Data = creditCards,
                    Message = "Credit Cards Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCustomerCreditCard(CreditCardCreateDTO creditCard)
        {
            try
            {
                _services.CardCreditCardService.CreateCustomerCreditCard(creditCard);

                return Ok(new Response<object>
                {
                    Message = "Credit Card Created"
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

        [Route("{creditCardId}")]
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteCustomerCreditCard(Guid creditCardId)
        {
            try
            {
                _services.CardCreditCardService.DeleteCustomerCreditCard(creditCardId);

                return Ok(new Response<object>
                {
                    Message = "Credit Card Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateCustomerCreditCard(CreditCardDTO creditCard)
        {
            try
            {
                _services.CardCreditCardService.UpdateCustomerCreditCard(creditCard);

                return Ok(new Response<object>
                {
                    Message = "Credit Card Updated"
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
    }
}
