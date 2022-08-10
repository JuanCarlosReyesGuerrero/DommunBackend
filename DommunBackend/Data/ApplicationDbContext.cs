using DommunBackend.DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DommunBackend.DomainLayer.DTOs;

namespace DommunBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TipoZona> TipoZonas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            //this.SeedRoles(builder);
            //this.SeedUserRoles(builder);
        }

        //public DbSet<DommunBackend.DomainLayer.DTOs.MunicipioDto>? MunicipioDto { get; set; }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "ce9e7f01-a8f7-4234-b81a-ab36a6e74faa", Name = "Agente", ConcurrencyStamp = "2fc9bd3c-1b84-4489-8712-00b38e92cc0e", NormalizedName = "AGENTE" },
                new IdentityRole() { Id = "fa327e3c-9f7d-4081-b0b3-657d3572b58e", Name = "SuperAdmin", ConcurrencyStamp = "2219f073-99dd-4a5a-abfc-10cf3d0b1e58", NormalizedName = "SUPERADMIN" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "ce9e7f01-a8f7-4234-b81a-ab36a6e74faa", UserId = "7074f8ef-a02b-4593-821f-b148c5687b66" },
                new IdentityUserRole<string>() { RoleId = "fa327e3c-9f7d-4081-b0b3-657d3572b58e", UserId = "7074f8ef-a02b-4593-821f-b148c5687b66" }
                );
        }

        public DbSet<DommunBackend.DomainLayer.DTOs.AgenteDto>? AgenteDto { get; set; }

        public DbSet<DommunBackend.DomainLayer.DTOs.ZonificacionDto>? ZonificacionDto { get; set; }

        public DbSet<DommunBackend.DomainLayer.DTOs.PlanMembresiaDto>? PlanMembresiaDto { get; set; }

        //public DbSet<DommunBackend.DomainLayer.DTOs.DepartamentoDto>? DepartamentoDto { get; set; }

    }
}