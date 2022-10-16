using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SaleItemDTO
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public RefundStatus RefundStatus { get; set; }
        public decimal UnitValue { get; set; }
        public uint Quantity { get; set; }

        public ProductDTO Product { get; set; }
    }

    public class SaleItemSummaryDTO
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; } 
    }
}
