using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class InactiveReasonDTO
    {
        public Guid? Id { get; set; }
        public Guid InactiveCategoryId { get; set; }
        public string Description { get; set; }

        public InactiveCategoryDTO? InactiveCategory { get; set; }
    }
}
