using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroStockAPI.Context.Mappping
{
    public class CardFlagMapping : IEntityTypeConfiguration<CardFlag>
    {
        public void Configure(EntityTypeBuilder<CardFlag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable("tb_card_flags");
        }
    }
}
