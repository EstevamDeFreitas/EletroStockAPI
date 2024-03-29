﻿using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Notations;
using Services.Services.Interfaces;
using Services.Utilities;

namespace EletroStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public SaleController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetSale(Guid id)
        {
            try
            {

                var sales = _serviceWrapper.SaleService.GetSale(id);

                return Ok(new Response<SaleDTO>
                {
                    Data = sales,
                    Message = "Sale Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCustomerSales()
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                var sales = _serviceWrapper.SaleService.GetSalesFromCustomer(user);

                return Ok(new Response<List<SaleDTO>>
                {
                    Data = sales,
                    Message = "Sales Found"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCustomerSale([FromBody]SaleCreateDTO saleCreate)
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                _serviceWrapper.SaleService.GenerateSale(saleCreate, user);

                return Ok(new Response<object>
                {
                    Message = "Sale Created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult ChangeSaleStatus(Guid id, [FromQuery] SaleStatus saleStatus)
        {
            try
            {
                _serviceWrapper.SaleService.ChangeSaleStatus(id, saleStatus);

                return Ok(new Response<object>
                {
                    Message = "Sale Status Changed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllSales()
        {
            try
            {
                var sales = _serviceWrapper.SaleService.GetSales();

                return Ok(new Response<List<SaleDTO>>
                {
                    Data = sales,
                    Message = "Sales Found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPost("refund")]
        [Authorize]
        public IActionResult RefundSaleItems([FromBody] List<SaleItemSummaryDTO> saleItems)
        {
            try
            {
                var user = Guid.Parse((string)HttpContext.Items["User"]);

                _serviceWrapper.SaleService.RequestRefundSaleItems(saleItems, user);

                return Ok(new Response<object>
                {
                    Message = "Sales Refund Requested"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut("refund")]
        public IActionResult ChangeRefundStatusSaleItems([FromBody] SaleItemSummaryDTO saleItem, [FromQuery] RefundStatus refundStatus)
        {
            try
            {
                _serviceWrapper.SaleService.ChangeRefundStatus(saleItem, refundStatus);

                

                return Ok(new Response<object>
                {
                    Message = "Sales Refund Status Changed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpPut("refund/inventory")]
        public IActionResult AcceptRefundIntoInventory([FromBody] SaleItemSummaryDTO saleItem)
        {
            try
            {
                _serviceWrapper.SaleService.AcceptInventory(saleItem);

                return Ok(new Response<object>
                {
                    Message = "Products Returned To Stock"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }

        [HttpGet("summary")]
        public IActionResult GetSaleSummary([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] string? productCode, [FromQuery] bool isQuantity)
        {
            try
            {
                var sales = _serviceWrapper.SaleService.GetSaleSummary(isQuantity, startDate, endDate, productCode);

                return Ok(new Response<SaleSummary>
                {
                    Message = "Sale summary found",
                    Data = sales
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object> { Message = ex.Message });
            }
        }
    }
}
