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
        void GenerateSale(SaleCreateDTO saleCreateDTO, Guid customerId);
        void ChangeSaleStatus(Guid id, SaleStatus status);
        void RequestRefundSaleItems(List<SaleItemSummaryDTO> saleItems, Guid customerId);
        void ChangeRefundStatus(SaleItemSummaryDTO saleItem, RefundStatus refundStatus);
        void AcceptInventory(SaleItemSummaryDTO saleItem);
        SaleSummary GetSaleSummary(bool isQuantity, DateTime? startDate, DateTime? endDate, string? productCode);
    }
}
