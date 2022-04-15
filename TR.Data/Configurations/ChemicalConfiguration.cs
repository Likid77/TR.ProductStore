using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TR.Domain;

namespace TR.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(c => c.Address, labAddress =>
            {
                labAddress.Property(a => a.StreetAddress)
                .HasMaxLength(50)
                .HasColumnName("MyAddress");

                labAddress.Property(a => a.City)
                .IsRequired()
                .HasColumnName("MyCity");
            });
        }
    }
}
