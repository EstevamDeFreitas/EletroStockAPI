using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IStockService
    {
        StockDTO GetStock(Guid id);
        List<StockDTO> GetStocks();
        void UpdateStock(StockDTO stock);
        void CreateStock(StockDTO stock);
        void DeleteStock(Guid id);
    }
}
