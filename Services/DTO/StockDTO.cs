using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string SourceName { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
