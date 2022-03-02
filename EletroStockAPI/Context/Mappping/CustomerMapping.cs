using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroStockAPI.Context.Mappping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.PhoneCode).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.PhoneType).IsRequired();
            builder.Property(x => x.Ranking).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            

            builder.ToTable("tb_customers");

        }
    }
}
