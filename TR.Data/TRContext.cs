using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TR.Data.Configuration;
using TR.Domain;

namespace TR.Data
{
    public class TRContext : DbContext
    {
        // Virtual tables
        DbSet<Product> Products { get; set; }
        DbSet<Chemical> Chemicals { get; set; }
        DbSet<Biological> Biologicals { get; set; }

        DbSet<Provider> Providers { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = (localdb)\mssqllocaldb; initial catalog = TRProductStore; integrated security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            //modelBuilder.Entity<Product>().Ignore(p => p.Price);
            //modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("Nom Produit").HasMaxLength(50).HasDefaultValue("Name").IsRequired();
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            // Stratégie TPT: Table Per Type
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Biological>().ToTable("Biologicals");
            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
        }
    }
}
