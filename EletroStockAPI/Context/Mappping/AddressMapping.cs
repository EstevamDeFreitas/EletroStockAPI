using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroStockAPI.Context.Mappping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.CEP).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.StreetType).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId);

            builder.ToTable("tb_addresses");

        }
    }
}
