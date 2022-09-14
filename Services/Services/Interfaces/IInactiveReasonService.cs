using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IInactiveReasonService
    {
        List<InactiveReasonDTO> GetInactiveReasons();
        InactiveReasonDTO GetInactiveReason(Guid id);
        void DeleteInactiveReason(Guid id);
        void CreateInactiveReason(InactiveReasonDTO inactiveReason);
        void UpdateInactiveReason(InactiveReasonDTO inactiveReason);
    }
}
