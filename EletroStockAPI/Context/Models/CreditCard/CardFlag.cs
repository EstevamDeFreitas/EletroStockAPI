using System.ComponentModel.DataAnnotations.Schema;

namespace EletroStockAPI.Context.Models
{
    public class CardFlag
    {
        [Column("car_id")]
        public string Id { get; set; }
        [Column("car_name")]
        public string Name { get; set; }

    }
}
