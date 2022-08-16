using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database
{
    public class EletroStockContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public EletroStockContext(DbContextOptions<EletroStockContext> options) : base(options)
        {

        }
    }
}
