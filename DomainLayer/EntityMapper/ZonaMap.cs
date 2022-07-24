using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class ZonaMap : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Slug).IsRequired();
            builder.Property(t => t.Nombre).IsRequired();

            //builder.HasOne(t => t.TipoZona).WithOne(b => b.Zonas).HasForeignKey(b => b.TipoZonaId)
            //.OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
