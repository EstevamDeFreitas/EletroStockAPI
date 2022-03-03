using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepositoryBase
    {
        public List<CreditCard> GetCustomerCreditCards(string customerId);
        public bool AddCreditCard(CreditCard creditCard);
        public bool UpdateCreditCard(CreditCard creditCard);
        public bool DeleteCreditCard(CreditCard creditCard);
    }
}
