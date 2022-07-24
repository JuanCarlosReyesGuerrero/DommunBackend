using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class TipoZonaMap : IEntityTypeConfiguration<TipoZona>
    {
        public void Configure(EntityTypeBuilder<TipoZona> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Codigo).IsRequired();
            builder.Property(t => t.Nombre).IsRequired();
        }
    }
}
