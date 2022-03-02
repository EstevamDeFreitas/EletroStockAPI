namespace EletroStockAPI.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public char Status { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string PhoneType { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public int Ranking { get; set; }
    }
}
