using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroStockAPI.Context.Mappping
{
    public class CustomerAccountMapping : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer).WithOne(x => x.CustomerAccount).HasForeignKey<CustomerAccount>(x => x.CustomerId);
            builder.HasOne(x => x.ChargeAddress).WithOne(x => x.CustomerAccount).HasForeignKey<CustomerAccount>(x => x.ChargeAddressId);
            builder.HasOne(x => x.DeliveryAddress).WithOne(x => x.CustomerAccount).HasForeignKey<CustomerAccount>(x => x.DeliveryAddressId);
            builder.HasOne(x => x.Card).WithOne(x => x.CustomerAccount).HasForeignKey<CustomerAccount>(x => x.CardId);

            builder.ToTable("tb_customer_account");
        }
    }
}
