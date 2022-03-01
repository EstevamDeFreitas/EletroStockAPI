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
        }
    }
}
