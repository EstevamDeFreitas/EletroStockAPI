using AutoMapper;
using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Models;
using EletroStockAPI.Models.Shared;
using EletroStockAPI.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly ICustomerAccountRepository _customerAccountRepository;
        private readonly IMapper _mapper;
        public CreditCardsController(ICreditCardRepository creditCardRepository, ICustomerAccountRepository customerAccountRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _customerAccountRepository = customerAccountRepository;
            _mapper = mapper;
        }

        [Route("creditflags")]
        [HttpGet]
        public IActionResult GetCardFlags()
        {
            try
            {
                var flags = _creditCardRepository.GetCardFlags();

                return Ok(new MessageBase<List<CardFlag>>
                {
                    Message = Message.Success,
                    Result = flags
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message});
            }
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCustomerCreditCard(string id)
        {
            try
            {
                var creditCard = _creditCardRepository.GetCustomerCreditCards(id);

                return Ok(new MessageBase<List<CreditCard>>
                {
                    Message = Message.Success,
                    Result = creditCard
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message});
            }
        }

        [HttpPost]
        public IActionResult CreateCustomerCreditCard([FromBody] CreditCardCreateModel creditCardModel)
        {
            try
            {
                var creditCardEntity = _mapper.Map<CreditCard>(creditCardModel);
                creditCardEntity.Id = EntityHelper.GenerateGuid();

                var result = _creditCardRepository.AddCreditCard(creditCardEntity);

                if (!result)
                {
                    return BadRequest(new MessageBase<object> { Message = Message.Error });
                }

                var customerAccount = _customerAccountRepository.GetCustomerAccount(creditCardEntity.IdCustomer);

                if(customerAccount != null)
                {
                    if(customerAccount.CardId == null)
                    {
                        customerAccount.CardId = creditCardEntity.Id;

                        _customerAccountRepository.UpdateCustomerAccount(customerAccount);
                    }
                }

                return Ok(new MessageBase<object>
                {
                    Message = Message.Success,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object>{ Message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult EditCustomerCreditCard([FromBody] CreditCardModel creditCard)
        {
            try
            {
                var creditCardEntity = _mapper.Map<CreditCard>(creditCard);

                var result = _creditCardRepository.UpdateCreditCard(creditCardEntity);

                if (!result)
                {
                    return BadRequest(new MessageBase<object> { Message = Message.Error });
                }

                return Ok(new MessageBase<object>
                {
                    Message = Message.Success,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCustomerCreditCard(string id)
        {
            try
            {
                var creditCard = _creditCardRepository.GetCredit(id);

                if (creditCard == null)
                {
                    return NotFound(new MessageBase<object> { Message=Message.NotFound });
                }

                var customerAccount = _customerAccountRepository.GetCustomerAccount(creditCard.IdCustomer);

                if(customerAccount != null)
                {
                    if(customerAccount.CardId == id)
                    {
                        return BadRequest(new MessageBase<object> { Message = Message.ObjectInUse });
                    }
                }

                var result = _creditCardRepository.DeleteCreditCard(creditCard);

                return Ok(new MessageBase<object>
                {
                    Message = Message.Success,
                    Result = result
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageBase<object> { Message=ex.Message });
            }
        }
    }
}
