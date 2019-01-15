using Microsoft.EntityFrameworkCore;
using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Persistence
{
    public class PTSDbContext : DbContext
    {
        public PTSDbContext() : base() { }

        public PTSDbContext(DbContextOptions<PTSDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost;Port=5432;Database=pts;User Id=pts;Password=jed8703
            //optionsBuilder.UseNpgsql("Server=localhost;Port=12345;Database=pts;User Id=pts;Password=jed8703");
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=pts;User Id=pts;Password=jed8703");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PTSDbContext).Assembly);
        }
    }
}
