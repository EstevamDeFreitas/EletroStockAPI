using Domain.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ISaleService
    {
        SaleDTO GetSale(Guid id);
        List<SaleDTO> GetSalesFromCustomer(Guid customerId);
        List<SaleDTO> GetSales();
        void GenerateSale(SaleCreateDTO saleCreateDTO);
        void ChangeSaleStatus(Guid id, SaleStatus status);
    }
}
