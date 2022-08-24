using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_addresses")]
    public class Address : EntityBase
    {
        [Required]
        [Column("address_type")]
        [MaxLength(40)]
        public string AddressType { get; set; }
        [Required]
        [Column("street_type")]
        [MaxLength(40)]
        public string StreetType { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column("street")]
        [MaxLength(255)]
        public string Street { get; set; }
        [Required]
        [Column("number")]
        public int Number { get; set; }
        [Required]
        [Column("district")]
        [MaxLength(50)]
        public string District { get; set; }
        [Required]
        [Column("cep")]
        [StringLength(8)]
        public string CEP { get; set; }
        [Required]
        [Column("City")]
        [MaxLength(255)]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [Column("country")]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
    }
}
