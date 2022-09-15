using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IPriceGroupService
    {
        PriceGroupDTO GetPriceGroup(Guid id);
        List<PriceGroupDTO> GetPriceGroups();
        void UpdatePriceGroup(PriceGroupDTO priceGroup);
        void CreatePriceGroup(PriceGroupDTO priceGroup);
        void DeletePriceGroup(Guid id);
    }
}
