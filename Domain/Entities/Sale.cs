using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("etk_sales")]
    public class Sale : EntityBase
    {
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Required]
        [Column("address_id")]
        public Guid AddressId { get; set; }
        [Required]
        [Column("sale_status")]
        public SaleStatus SaleStatus { get; set; }
        [Required]
        [Column("dt_sale")]
        public DateTime SaleDate { get; set; }
        [Required]
        [Column("vl_shipping")]
        public decimal Shipping { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public List<SalePayment> SalePayments { get; set; }
        public List<SaleCoupon>? SaleCoupons { get; set; }

        public Sale() { }

        public Sale(Guid customerId, Guid addressId, decimal shipping)
        {
            CustomerId = customerId;
            AddressId = addressId;
            SaleStatus = SaleStatus.Analisys;
            SaleDate = DateTime.Now;
            Shipping = shipping;
            this.Generate();
        }
    }

    public enum SaleStatus
    {
        Analisys,
        PaymentConfirmed,
        Transporting,
        Delivered,
        Finished,
        RefundRequested
    }
}
