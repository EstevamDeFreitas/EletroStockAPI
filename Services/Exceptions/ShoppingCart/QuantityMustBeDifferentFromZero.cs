using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.ShoppingCart
{
    [Serializable]
    public class QuantityMustBeDifferentFromZero : Exception
    {
        public QuantityMustBeDifferentFromZero() : base("Quantity selected must be higher than zero")
        {

        }
    }
}
