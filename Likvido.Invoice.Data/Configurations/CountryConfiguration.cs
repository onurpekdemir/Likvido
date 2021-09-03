using Likvido.Invoice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likvido.Invoice.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> modelBuilder)
        {
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Name).IsRequired();
            modelBuilder.Property(s => s.CreatedDate).IsRequired(true);
            modelBuilder.Property(s => s.CreatedBy).IsRequired(true);
            modelBuilder.Property(s => s.UpdatedBy).IsRequired(false);
            modelBuilder.Property(s => s.UpdatedDate).IsRequired(false);
        }
    }
}
