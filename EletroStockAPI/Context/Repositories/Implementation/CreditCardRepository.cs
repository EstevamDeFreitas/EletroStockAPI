using EletroStockAPI.Context.Models;
using EletroStockAPI.Context.Repositories.Interfaces;

namespace EletroStockAPI.Context.Repositories.Implementation
{
    public class CreditCardRepository : RepositoryBase, ICreditCardRepository
    {
        public CreditCardRepository(AppDbContext context) : base(context)
        {
        }

        public bool AddCreditCard(CreditCard creditCard)
        {
            try
            {
                context.CreditCards.Add(creditCard);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCreditCard(CreditCard creditCard)
        {
            try
            {
                context.CreditCards.Remove(creditCard);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CreditCard? GetCredit(string id)
        {
            return context.CreditCards.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<CreditCard> GetCustomerCreditCards(string customerId)
        {
            return context.CreditCards.Where(x => x.IdCustomer == customerId).ToList();
        }

        public bool UpdateCreditCard(CreditCard creditCard)
        {
            try
            {
                context.CreditCards.Update(creditCard);
                EndTransaction(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
