using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class CreditCardService : ServiceBase, ICreditCardService
    {
        public CreditCardService(IRepositoryWrapper repository) : base(repository)
        {
        }

        public void CreateCustomerCreditCard(CreditCardCreateDTO creditCard)
        {
            var newCreditCard = new CreditCard
            {
                CardFlagId = creditCard.CardFlagId,
                CardNumber = creditCard.CardNumber,
                CustomerId = creditCard.CustomerId,
                OwnerName = creditCard.OwnerName,
                SecurityCode = creditCard.SecurityCode
            };

            newCreditCard.Generate();

            _repository.CreditCardRepository.Create(newCreditCard);
            _repository.Save();

            if (_repository.CreditCardRepository.FindByCondition(x => x.CustomerId == newCreditCard.CustomerId).ToList().Count() == 1)
            {
                var customerAccount = _repository.CustomerAccountRepository.FindByCondition(x => x.CustomerId == newCreditCard.CustomerId).FirstOrDefault();

                if (customerAccount is not null)
                {
                    customerAccount.DefaultCreditCardId = newCreditCard.Id;

                    _repository.CustomerAccountRepository.Update(customerAccount);
                    _repository.Save();
                }


            }
        }

        public void DeleteCustomerCreditCard(Guid cardId)
        {
            var creditCardFound = _repository.CreditCardRepository.FindByCondition(x => x.Id == cardId).FirstOrDefault();

            if(creditCardFound is null)
            {
                throw new NotFound("Credit Card");
            }

            _repository.CreditCardRepository.Delete(creditCardFound);
            _repository.Save();

        }

        public CreditCardDTO GetCreditCard(Guid cardId)
        {
            var creditCardFound = _repository.CreditCardRepository.FindByCondition(x => x.Id == cardId).FirstOrDefault();

            if (creditCardFound is null)
            {
                throw new NotFound("Credit Card");
            }

            return new CreditCardDTO
            {
                CardFlagId = creditCardFound.CardFlagId,
                CardNumber = creditCardFound.CardNumber,
                CustomerId = creditCardFound.CustomerId,
                Id = creditCardFound.Id,
                OwnerName = creditCardFound.OwnerName,
                SecurityCode = creditCardFound.SecurityCode
            };
        }

        public List<CreditCardDTO> GetCustomerCreditCards(Guid customerId)
        {
            var creditCards = _repository.CreditCardRepository.FindByCondition(x => x.CustomerId == customerId).Select(x => new CreditCardDTO
            {
                CustomerId = customerId,
                Id = x.Id,
                CardFlagId = x.CardFlagId,
                CardNumber = x.CardNumber,
                OwnerName = x.OwnerName,
                SecurityCode = x.SecurityCode
            }).ToList();


            return creditCards; 
        }

        public void UpdateCustomerCreditCard(CreditCardDTO creditCard)
        {
            var creditCardFound = _repository.CreditCardRepository.FindByCondition(x => x.Id == creditCard.Id).FirstOrDefault();

            if (creditCardFound is null)
            {
                throw new NotFound("Credit Card");
            }

            creditCardFound.CardNumber = creditCard.CardNumber;
            creditCardFound.CardFlagId = creditCard.CardFlagId;
            creditCardFound.OwnerName = creditCard.OwnerName;
            creditCardFound.SecurityCode = creditCard.SecurityCode;

            _repository.CreditCardRepository.Update(creditCardFound);
            _repository.Save();
        }
    }
}
