using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(Guid id);
        List<ProductDTO> GetProducts();
        void CreateProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(Guid id);
        void DisableProduct(Guid id, InactiveReasonDTO inactiveReason);
    }
}
