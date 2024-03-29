﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SaleDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Shipping { get; set; }

        public decimal Total
        {
            get 
            {
                var totalSaleValue = SaleItems.Sum(x => x.UnitValue * x.Quantity) + Shipping;

                if(SaleCoupons is not null && SaleCoupons.Count > 0)
                {
                    totalSaleValue -= SaleCoupons.Sum(x => x.DiscountValue);
                }

                return totalSaleValue;
            }
        }

        public List<SaleItemDTO> SaleItems { get; set; }
        public List<SalePaymentDTO> SalePayments { get; set; }
        public List<SaleCouponDTO>? SaleCoupons { get; set; }
        public CustomerDTO Customer { get; set; }
    }

    public class SaleCreateDTO
    {
        public Guid ShoppingCartId { get; set; }
        public Guid AddressId { get; set; }
        public decimal Shipping { get; set; }
        public List<ValueById> CreditCards { get; set; }
        public List<ValueById>? CustomerCoupons { get; set; }
    }

    public class ValueById
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
    }
}
