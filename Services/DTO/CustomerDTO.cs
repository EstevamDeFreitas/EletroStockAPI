using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CustomerDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string PhoneType { get; set; }
        public decimal PhoneCode { get; set; }
        public decimal PhoneNumber { get; set; }
        public int Ranking { get; set; }
    }
}
