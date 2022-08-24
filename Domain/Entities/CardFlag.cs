using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_card_flags")]
    public class CardFlag : EntityBase
    {
        [Required]
        [Column("name")]
        [StringLength(75)]
        public string Name { get; set; }

        public List<CreditCard> CreditCards { get; set; }
    }
}
