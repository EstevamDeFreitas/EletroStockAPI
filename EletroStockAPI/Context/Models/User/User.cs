using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class User
    {
        [Column("usr_id")]
        public string Id { get; set; }
        [Column("usr_email")]
        public string Email { get; set; }
        [Column("usr_password")]
        public string Password { get; set; }
        [Column("usr_status")]
        public char Status { get; set; }
        [Column("usr_user_type")]
        public char UserType { get; set; }

    }
}
