using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class Customer
    {
        [Column("cus_id")]
        public string Id { get; set; }
        [Column("cus_id_user")]
        public string UserId { get; set; }
        [Column("cus_name")]
        public string Name { get; set; }
        [Column("cus_status")]
        public char Status { get; set; }
        [Column("cus_gender")]
        public string Gender { get; set; }
        [Column("cus_birth")]
        public DateTime BirthDate { get; set; }
        [Column("cus_cpf")]
        public string CPF { get; set; }
        [Column("cus_phone_type")]
        public string PhoneType { get; set; }
        [Column("cus_phone_code")]
        public string PhoneCode { get; set; }
        [Column("cus_phone_number")]
        public string PhoneNumber { get; set; }
        [Column("cus_ranking")]
        public int Ranking { get; set; }

        //Relation
        public User User { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<CreditCard> Cards { get; set; }
        //public List<Coupon> Coupons { get; set; }
    }
}
