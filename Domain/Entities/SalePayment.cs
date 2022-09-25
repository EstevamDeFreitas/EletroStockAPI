using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_sale_payments")]
    public class SalePayment
    {
        [Required]
        [Column("credit_card_id")]
        public Guid CreditCardId { get; set; }
        [Required]
        [Column("sale_id")]
        public Guid SaleId { get; set; }
        [Required]
        [Column("vl_paid")]
        public decimal ValuePaid { get; set; }

        public CreditCard CreditCard { get; set; }
        public Sale Sale { get; set; }
    }
}
