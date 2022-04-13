using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;

namespace TR.Data.Configurations
{
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            builder.HasKey(f => new
            {
                f.ClientFK,
                f.ProductFK
            });
            builder
                .HasOne(f => f.Client)
                .WithMany(c => c.Factures)
                .HasForeignKey(f => f.ClientFK);
            builder
                .HasOne(f => f.Product)
                .WithMany(p => p.Factures)
                .HasForeignKey(f => f.ProductFK);
        }
    }
}
