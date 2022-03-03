using EletroStockAPI.Context.Models;

namespace EletroStockAPI.Context.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepositoryBase
    {
        public List<CreditCard> GetCustomerCreditCards(string customerId);
        public bool AddCreditCard(string customerId, CreditCard creditCard);
        public bool UpdateCreditCard(string customerId, CreditCard creditCard);
        public bool DeleteCreditCard(CreditCard creditCard);
    }
}
