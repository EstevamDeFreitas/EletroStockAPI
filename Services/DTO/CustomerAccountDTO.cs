using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CustomerAccountDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? DefaultChargeAddressId { get; set; }
        public Guid? DefaultDeliveryAddressId { get; set; }
        public Guid? DefaultCreditCardId { get; set; }
    }
}
