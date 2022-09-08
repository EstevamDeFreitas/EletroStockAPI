using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_inactive_reasons")]
    public class InactiveReason : EntityBase
    {
        [Required]
        [Column("inactive_category_id")]
        public Guid InactiveCategoryId { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        public InactiveCategory InactiveCategory { get; set; }
    }
}
