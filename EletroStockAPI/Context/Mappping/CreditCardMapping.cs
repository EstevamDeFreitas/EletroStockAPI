using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroStockAPI.Context.Mappping
{
    public class CreditCardMapping : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.SecurityCode).IsRequired();
            builder.Property(x => x.IdCustomer).IsRequired();
            builder.Property(x => x.FlagId).IsRequired();

            builder.ToTable("tb_credit_cards");
        }
    }
}
