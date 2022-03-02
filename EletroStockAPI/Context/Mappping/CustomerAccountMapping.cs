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
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CardId);
            builder.Property(x => x.ChargeAddressId).IsRequired();
            builder.Property(x => x.DeliveryAddressId).IsRequired();

            builder.ToTable("tb_customer_account");
        }
    }
}
