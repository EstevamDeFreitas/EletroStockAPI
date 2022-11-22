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
        public List<ProductSummary> MonthlyProductValue { get; set; }

        public void Order()
        {
            var months = MonthlyProductValue.SelectMany(x => x.Values).Select(x => x.Month).Distinct().ToList();

            MonthlyProductValue = MonthlyProductValue.OrderBy(x => x.ProductName).ToList();

            MonthlyProductValue.ForEach(prod =>
            {
                prod.Values = prod.Values.OrderBy(x => x.Month).ToList();
            });
        }
    }

    public class ProductSummary
    {
        public string ProductName { get; set; }
        public List<MonthlyData<decimal>> Values { get; set; }
    }
}
