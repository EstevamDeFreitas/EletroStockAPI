using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository CustomerRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICreditCardRepository CreditCardRepository { get; }
        ICardFlagRepository CardFlagRepository { get; }
        void Save();
    }
}
