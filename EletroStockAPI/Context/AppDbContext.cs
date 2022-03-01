using EletroStockAPI.Context.Mappping;
using EletroStockAPI.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace EletroStockAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMapping());
        }
    }
}
