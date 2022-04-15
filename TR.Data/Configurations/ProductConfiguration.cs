using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TR.Domain;

namespace TR.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Ignore(p => p.Price);
            builder.Property(p => p.Name).HasColumnName("Nom Produit").HasMaxLength(50).HasDefaultValue("Name").IsRequired();

            builder.HasMany(p => p.Providers).WithMany(p => p.Products).UsingEntity(t => t.ToTable("Providings"));
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade); // ou .OnDelete(DeleteBehavior.SetNull) si on ne veut pas utiliser la suppression en cascade
            //builder.HasDiscriminator<int>("Type").HasValue<Product>(0).HasValue<Biological>(1).HasValue<Chemical>(2);

        }
    }
}
