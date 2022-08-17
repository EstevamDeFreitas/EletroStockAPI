using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Customer
{
    [Serializable]
    public class CustomerNotFound : Exception
    {
        public CustomerNotFound() : base("Customer not found.") { }
    }
}
