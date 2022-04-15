using Microsoft.EntityFrameworkCore;
using TR.Data.Configurations;
using TR.Domain;

namespace TR.Data
{
    public class TRContext : DbContext
    {
        // Virtual tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"data source = (localdb)\mssqllocaldb; initial catalog = TRProductStore; integrated security = true")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appel aux classes de configuration nouvellement créées - Méthode 1
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
            //modelBuilder.ApplyConfiguration(new FactureConfiguration());

            // Appel aux classes de configuration nouvellement créées - Méthode 2
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ChemicalConfiguration().Configure(modelBuilder.Entity<Chemical>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new FactureConfiguration().Configure(modelBuilder.Entity<Facture>());

            // Configuration de toutes les propriétés de type string dont le nom commence par "Name"
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name")))
            { property.SetColumnName("MyName"); }

            // TPH: Table Per Hierarchy
            //modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            //modelBuilder.Entity<Product>().Ignore(p => p.Price);
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Name)
            //    .HasColumnName("Nom Produit")
            //    .HasMaxLength(50)
            //    .HasDefaultValue("Name")
            //    .IsRequired();

            // TPT: Table Per Type
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Biological>().ToTable("Biologicals");
            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            modelBuilder.Entity<Category>().ToTable("MyCategories");
            modelBuilder.Entity<Client>().ToTable("Clients");
            //modelBuilder.Entity<Facture>().ToTable("Factures");
        }
    }
}
