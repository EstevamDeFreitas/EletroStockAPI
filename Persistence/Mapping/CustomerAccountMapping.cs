using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping
{
    public class CustomerAccountMapping : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            //Removido para permitir que endereço seja opcional durante a criação da conta
            //builder.HasOne(x => x.DefaultChargeAddress)
            //        .WithOne(x => x.DefaultChargeAddressCustomerAccount)
            //        .HasForeignKey<CustomerAccount>(x => x.DefaultChargeAddressId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.DefaultDeliveryAddress)
            //        .WithOne(x => x.DefaultDeliveryAddressCustomerAccount)
            //        .HasForeignKey<CustomerAccount>(x => x.DefaultDeliveryAddressId)
            //        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
