using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_inactive_categories")]
    public class InactiveCategory : EntityBase
    {
        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column("active")]
        public bool Active { get; set; }

        public List<InactiveReason> InactiveReasons { get; set; }
    }
}
