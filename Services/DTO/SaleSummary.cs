using Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SaleSummary
    {
        public List<string> Products { get; set; }
        public List<MonthlyData<List<ProductSummary>>> MonthlyProductValue { get; set; }

        public void Order()
        {
            Products = Products.OrderBy(x => x).ToList();
            MonthlyProductValue = MonthlyProductValue.OrderBy(x => x.Month).ToList();
            MonthlyProductValue.ForEach(month =>
            {
                Products.ForEach(prod =>
                {
                    
                });
            });
        }
    }

    public class ProductSummary
    {
        public string ProductName { get; set; }
        public decimal Value { get; set; }
    }
}
