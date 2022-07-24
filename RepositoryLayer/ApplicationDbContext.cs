using DomainLayer.EntityMapper;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TipoZona>()
            //            .HasMany(c => c.Zonas)
            //            .WithOne(e => e.TipoZona);

            modelBuilder.Entity<Zona>()
              .HasOne(p => p.TipoZona)
              .WithMany(b => b.Zonas)
              .HasForeignKey(p => p.TipoZonaId);

            modelBuilder.Entity<Municipio>()
              .HasOne(p => p.Departamento)
              .WithMany(b => b.Municipios)
              .HasForeignKey(p => p.DepartamentoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TipoZona> TipoZonas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
    }
}
