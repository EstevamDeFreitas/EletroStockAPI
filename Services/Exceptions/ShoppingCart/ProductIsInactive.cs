using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.ShoppingCart
{
    [Serializable]
    public class ProductIsInactive : Exception
    {
        public ProductIsInactive(string product) : base($"Product {product} is not available")
        {

        }
    }
}
