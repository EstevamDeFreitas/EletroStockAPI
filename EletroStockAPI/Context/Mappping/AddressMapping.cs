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
            builder.Property(x => x.AddressType);
            builder.Property(x => x.City);
            builder.Property(x => x.CEP);
            builder.Property(x => x.Country);
            builder.Property(x => x.Description);
            builder.Property(x => x.District);
            builder.Property(x => x.Number);
            builder.Property(x => x.State);
            builder.Property(x => x.Street) ;
            builder.Property(x => x.StreetType);

            builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId);

            builder.ToTable("tb_addresses");

        }
    }
}
