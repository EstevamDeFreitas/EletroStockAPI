using EletroStockAPI.Context.Mappping;
using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace EletroStockAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CardFlag> CardFlags { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Mapping Configuration
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new CustomerMapping());
            builder.ApplyConfiguration(new AddressMapping());
            builder.ApplyConfiguration(new CardFlagMapping());
            builder.ApplyConfiguration(new CreditCardMapping());
            builder.ApplyConfiguration(new CustomerAccountMapping());
        }
    }
}
