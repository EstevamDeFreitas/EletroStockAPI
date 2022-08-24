﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mapping;
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CardFlag> CardFlags { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public EletroStockContext(DbContextOptions<EletroStockContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerAccountMapping());
        }
    }
}
