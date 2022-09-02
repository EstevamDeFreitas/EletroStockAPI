using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CreditCardDTO
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public string SecurityCode { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CardFlagId { get; set; }
        public string? CardFlag { get; set; }
    }

    public class CreditCardCreateDTO
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public string SecurityCode { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CardFlagId { get; set; }
    }
}
