using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class AddressDTO
    {
        public Guid? Id { get; set; }
        public string AddressType { get; set; }
        public string StreetType { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Guid CustomerId { get; set; }

    }
}
