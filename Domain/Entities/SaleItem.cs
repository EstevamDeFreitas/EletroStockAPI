﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_sale_items")]
    public class SaleItem
    {
        [Required]
        [Column("sale_id")]
        public Guid SaleId { get; set; }
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("refund_status")]
        public RefundStatus RefundStatus { get; set; }
        [Required]
        [Column("vl_unit")]
        public decimal UnitValue { get; set; }
        [Required]
        [Column("quantity")]
        public uint Quantity { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }

    public enum RefundStatus
    {
        None,
        Requested,
        Refunded,
        Rejected
    }
}