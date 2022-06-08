using CashRegisterNStock.DAL.Configurations;
using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CashRegisterNStock.DAL
{
    public class CrnsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1HNCA4J\\TB2021;initial catalog=Crns_Database; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new CategoryConfig());
            mb.ApplyConfiguration(new ProductConfig());
        }
    }
}
