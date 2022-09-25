using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SalePaymentDTO
    {
        public Guid CreditCardId { get; set; }
        public Guid SaleId { get; set; }
        public decimal ValuePaid { get; set; }

        public CreditCardDTO CreditCard { get; set; }
    }
}
