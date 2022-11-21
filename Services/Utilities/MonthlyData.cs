using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class MonthlyData<T>
    {
        public DateTime Month { get; set; }
        public T Data { get; set; }
    }
}
