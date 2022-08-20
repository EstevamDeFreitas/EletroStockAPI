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
        [Column("address_type")]
        [MaxLength(40)]
        public string AddressType { get; set; }
        [Column("street_type")]
        [MaxLength(40)]
        public string StreetType { get; set; }
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Column("street")]
        [MaxLength(255)]
        public string Street { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("district")]
        [MaxLength(50)]
        public string District { get; set; }
        [Column("cep")]
        [StringLength(8)]
        public string CEP { get; set; }
        [Column("City")]
        [MaxLength(255)]
        public string City { get; set; }
        [Column("state")]
        [StringLength(2)]
        public string State { get; set; }
        [Column("country")]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
