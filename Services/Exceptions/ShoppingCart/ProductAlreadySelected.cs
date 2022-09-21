using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.ShoppingCart
{
    [Serializable]
    public class ProductAlreadySelected : Exception
    {
        public ProductAlreadySelected(string product) : base($"Product {product} Already Selected")
        {

        }
    }
}
