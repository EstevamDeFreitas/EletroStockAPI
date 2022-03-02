using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class Address
    {
        [Column("add_id")]
        public string Id { get; set; }
        [Column("add_id_customer")]
        public string CustomerId { get; set; }
        [Column("add_address_type")]
        public string AddressType { get; set; }
        [Column("add_street_type")]
        public string StreetType { get; set; }
        [Column("add_description")]
        public string Description { get; set; }
        [Column("add_street")]
        public string Street { get; set; }
        [Column("add_number")]
        public string Number { get; set; }
        [Column("add_district")]
        public string District { get; set; }
        [Column("add_cep")]
        public string CEP { get; set; }
        [Column("add_city")]
        public string City { get; set; }
        [Column("add_state")]
        public string State { get; set; }
        [Column("add_country")]
        public string Country { get; set; }

        //Relation
        public Customer Customer { get; set; }
        public CustomerAccount? CustomerAccount { get; set; }
    }
}
