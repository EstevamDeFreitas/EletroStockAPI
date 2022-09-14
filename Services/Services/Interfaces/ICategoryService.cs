using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICategoryService
    {
        CategoryDTO GetCategory(Guid id);
        List<CategoryDTO> GetCategories();
        void CreateCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
        void DeleteCategory(Guid id);
    }
}
