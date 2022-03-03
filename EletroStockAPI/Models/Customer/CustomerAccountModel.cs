namespace EletroStockAPI.Models
{
    public class CustomerAccountModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string ChargeAddressId { get; set; }
        public string DeliveryAddressId { get; set; }
        public string CardId { get; set; }
    }
}
