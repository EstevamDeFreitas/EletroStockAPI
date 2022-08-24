using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_customers")]
    public class Customer : EntityBase
    {
        [Required]
        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [MaxLength(255), MinLength(8)]
        public string Password { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("gender")]
        [MaxLength(1)]
        public char Gender { get; set; }
        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Column("cpf")]
        [StringLength(11)]
        public string CPF { get; set; }
        [Required]
        [Column("phone_type")]
        [MaxLength(30)]
        public string PhoneType { get; set; }
        [Required]
        [Column("phone_code")]
        [MaxLength(3)]
        public decimal PhoneCode { get; set; }
        [Required]
        [Column("phone_number")]
        [MaxLength(9)]
        public decimal PhoneNumber { get; set; }
        [Required]
        [Column("ranking")]
        public int Ranking { get; set; }

        public CustomerAccount CustomerAccount { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}
