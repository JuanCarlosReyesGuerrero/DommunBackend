using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TipoZona> TipoZonas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<PlanMembresia> PlanMembresias { get; set; }
        public DbSet<Zonificacion> Zonificaciones { get; set; }
        public DbSet<ZonaDommun> ZonaDommuns { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<GestionDocumental> GestionDocumentales { get; set; }
        public DbSet<CatGestionDocumental> CatGestionDocumentales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

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

            modelBuilder.Entity<Agente>()
                .HasOne(p => p.Zonificacion)
                .WithMany(b => b.Agentes)
             .  HasForeignKey(p => p.ZonificacionId);

            modelBuilder.Entity<Agente>()
                .HasOne(p => p.PlanMembresia)
                .WithMany(b => b.Agentes)
                .HasForeignKey(p => p.PlanMembresiaId);

            modelBuilder.Entity<Agente>()
                .HasOne(p => p.Municipio)
                .WithMany(b => b.Agentes)
                .HasForeignKey(p => p.MunicipioId);

            modelBuilder.Entity<GestionDocumental>()
               .HasOne(p => p.CatGestionDocumental)
               .WithMany(b => b.GestionDocumentales)
               .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Cliente>()
               .HasOne(p => p.Agente)
               .WithMany(b => b.Clientes)
               .HasForeignKey(p => p.AgenteId);

            modelBuilder.Entity<ZonaDommun>()
                .HasKey(bc => new { bc.AgenteId, bc.TipoZonaId });
            modelBuilder.Entity<ZonaDommun>()
                .HasOne(bc => bc.Agente)
                .WithMany(b => b.ZonaDommuns)
                .HasForeignKey(bc => bc.AgenteId);
            modelBuilder.Entity<ZonaDommun>()
                .HasOne(bc => bc.TipoZona)
                .WithMany(c => c.ZonaDommuns)
                .HasForeignKey(bc => bc.TipoZonaId);


            base.OnModelCreating(modelBuilder);
        }       
    }
}
