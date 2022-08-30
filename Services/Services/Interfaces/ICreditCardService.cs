using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICreditCardService
    {
        CreditCardDTO GetCreditCard(Guid cardId);
        List<CreditCardDTO> GetCustomerCreditCards(Guid customerId);
        void CreateCustomerCreditCard(CreditCardCreateDTO creditCard);
        void DeleteCustomerCreditCard(Guid cardId);
        void UpdateCustomerCreditCard(CreditCardDTO creditCard);
    }
}
