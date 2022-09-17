using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ProductDTO
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid PriceGroupId { get; set; }
        public Guid? InactiveReasonId { get; set; }
        public InactiveReasonDTO? InactiveReason { get; set; }
        public List<ProductCategoryDTO> ProductCategories { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }
    }

    public class ProductCategoryDTO
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
    }

    public class ProductImageDTO
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}
