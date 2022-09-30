using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Stock
{
    [Serializable]
    public class InsufficientStock : Exception
    {
        public InsufficientStock(string product) : base($"Não há estoque suficiente para consumir, produto: {product}")
        {
        }
    }
}
