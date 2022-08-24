using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_credit_cards")]
    public class CreditCard : EntityBase
    {
        [Required]
        [Column("card_number")]
        [StringLength(16)]
        public string CardNumber { get; set; }
        [Required]
        [Column("owner_name")]
        [MaxLength(255)]
        public string OwnerName { get; set; }
        [Required]
        [Column("name")]
        [StringLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid CardFlagId { get; set; }

        public CardFlag CardFlag { get; set; }
        public Customer Customer { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
    }
}
