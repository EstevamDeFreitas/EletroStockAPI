using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class CustomerAccount
    {
        [Column("cac_id")]
        public string Id { get; set; }
        [Column("cac_id_customer")]
        public string CustomerId { get; set; }
        [Column("cac_id_default_charge_address")]
        public string ChargeAddressId { get; set; }
        [Column("cac_id_default_delivery_addresses")]
        public string DeliveryAddressId { get; set; }
        [Column("cac_id_default_card")]
        public string CardId { get; set; }

    }
}
