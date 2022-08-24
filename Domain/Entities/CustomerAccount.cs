using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_customer_account")]
    public class CustomerAccount : EntityBase
    {
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Required]
        [Column("default_charge_address_id")]
        public Guid DefaultChargeAddressId { get; set; }
        [Required]
        [Column("default_delivery_address_id")]
        public Guid DefaultDeliveryAddressId { get; set; }
        [Required]
        [Column("default_credit_card_id")]
        public Guid DefaultCreditCardId { get; set; }

        public Customer Customer { get; set; }
        public Address DefaultChargeAddress { get; set; }
        public Address DefaultDeliveryAddress { get; set; }
        public CreditCard DefaultCreditCard { get; set; }
    }
}
