using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IInactiveCategoryService
    {
        List<InactiveCategoryDTO> GetInactiveCategories();
        InactiveCategoryDTO GetInactiveCategory(Guid id);
        void DeleteInactiveCategory(Guid id);
        void CreateInactiveCategory(InactiveCategoryDTO inactiveCategory);
        void UpdateInactiveCategory(InactiveCategoryDTO inactiveCategory);
    }
}
