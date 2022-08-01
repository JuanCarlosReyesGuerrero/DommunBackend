using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    //public partial class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext(DbContextOptions options) : base(options)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
        public DbSet<FotografiaPropiedad> FotografiaPropiedades { get; set; }
        public DbSet<TipoDocumentoPropiedad> TipoDocumentoPropiedades { get; set; }
        public DbSet<DocumentoPropiedad> DocumentoPropiedades { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<TipoCaracteristica> TipoCaracteristicas { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Vivienda> Viviendas { get; set; }
        public DbSet<Comercial> Comerciales { get; set; }
        public DbSet<Industrial> Industriales { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<PublicacionComercial> PublicacionComerciales { get; set; }
        public DbSet<PublicacionIndustrial> PublicacionIndustriales { get; set; }
        public DbSet<PublicacionLote> PublicacionLotes { get; set; }
        public DbSet<PublicacionVivienda> PublicacionViviendas { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");                
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(30).IsUnicode(false);                
            });

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
             .HasForeignKey(p => p.ZonificacionId);

            modelBuilder.Entity<Agente>()
                .HasOne(p => p.PlanMembresia)
                .WithMany(b => b.Agentes)
                .HasForeignKey(p => p.PlanMembresiaId);

            modelBuilder.Entity<Agente>()
                .HasOne(p => p.Municipio)
                .WithMany(b => b.Agentes)
                .HasForeignKey(p => p.MunicipioId);

            modelBuilder.Entity<DocumentoPropiedad>()
                .HasOne(p => p.TipoDocumentoPropiedad)
                .WithMany(b => b.DocumentoPropiedades)
                .HasForeignKey(p => p.TipoDocumentoPropiedadId);

            modelBuilder.Entity<GestionDocumental>()
               .HasOne(p => p.CatGestionDocumental)
               .WithMany(b => b.GestionDocumentales)
               .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Cliente>()
               .HasOne(p => p.Agente)
               .WithMany(b => b.Clientes)
               .HasForeignKey(p => p.AgenteId);

            modelBuilder.Entity<Caracteristica>()
               .HasOne(p => p.TipoCaracteristica)
               .WithMany(b => b.Caracteristicas)
               .HasForeignKey(p => p.TipoCaracteristicaId);

            modelBuilder.Entity<FotografiaPropiedad>()
               .HasOne(p => p.Propiedad)
               .WithMany(b => b.FotografiaPropiedades)
               .HasForeignKey(p => p.PropiedadId);

            modelBuilder.Entity<Propiedad>()
               .HasOne(p => p.Caracteristica)
               .WithMany(b => b.Propiedades)
               .HasForeignKey(p => p.CaracteristicaId);

            modelBuilder.Entity<Propiedad>()
               .HasOne(p => p.Municipio)
               .WithMany(b => b.Propiedades)
               .HasForeignKey(p => p.MunicipioId);

            modelBuilder.Entity<Propiedad>()
               .HasOne(p => p.Agente)
               .WithMany(b => b.Propiedades)
               .HasForeignKey(p => p.AgenteId);

            modelBuilder.Entity<Propiedad>()
               .HasOne(p => p.Cliente)
               .WithMany(b => b.Propiedades)
               .HasForeignKey(p => p.ClienteId);

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

            //modelBuilder.Entity<Propiedad>()
            //    .HasOne(b => b.Vivienda)
            //    .WithOne(i => i.Propiedad)
            //    .HasForeignKey<Vivienda>(b => b.PropiedadId);

            //modelBuilder.Entity<Propiedad>()
            //   .HasOne(b => b.Comercial)
            //   .WithOne(i => i.Propiedad)
            //   .HasForeignKey<Comercial>(b => b.PropiedadId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
