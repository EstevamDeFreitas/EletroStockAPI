namespace EletroStockAPI.Models
{
    public class AddressModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string AddressType { get; set; }
        public string StreetType { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class AddressCreateModel
    {
        public string AddressType { get; set; }
        public string StreetType { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
