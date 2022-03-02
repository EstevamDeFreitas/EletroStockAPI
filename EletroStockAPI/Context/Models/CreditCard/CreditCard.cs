using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class CreditCard
    {
        [Column("cre_id")]
        public string Id { get; set; }
        [Column("cre_id_customer")]
        public string IdCustomer { get; set; }
        [Column("cre_security_code")]
        public string SecurityCode { get; set; }
        [Column("cre_card_number")]
        public string Number { get; set; }
        [Column("cre_owner_name")]
        public string Name { get; set; }
        [Column("cre_id_flag")]
        public string FlagId { get; set; }

        //Relation
        public Customer Customer { get; set; }
        public CardFlag Flag { get; set; }
        public CustomerAccount? CustomerAccount { get; set; }
    }
}
