namespace EletroStockAPI.Models
{
    public class CreditCardModel
    {
        public string Id { get; set; }
        public string IdCustomer { get; set; }
        public string SecurityCode { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string FlagId { get; set; }
    }
}
