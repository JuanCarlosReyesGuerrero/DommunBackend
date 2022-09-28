﻿using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<EstadoPropiedad> EstadoPropiedades { get; set; }
        public DbSet<Fotografia> Fotografias { get; set; }        
        public DbSet<Inmobiliaria> Inmobiliarias { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<TipoPropiedad> TipoPropiedades { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<CaracteristicaPropiedad> CaracteristicaPropiedades { get; set; }
        public DbSet<Estrato> Estratos { get; set; }
        public DbSet<TipoCaracteristica> TipoCaracteristicas { get; set; }        
        public DbSet<TipoOferta> TipoOfertas { get; set; }
        public DbSet<TiempoConstruido> TiempoConstruidos { get; set; }
        public DbSet<TipoParqueadero> TipoParqueaderos { get; set; }
        public DbSet<CaracteristicaParqueadero> CaracteristicaParqueaderos { get; set; }        
        public DbSet<NumeroBano> NumeroBanos { get; set; }
        public DbSet<NumeroHabitacion> NumeroHabitaciones { get; set; }
        public DbSet<NumeroParqueadero> NumeroParqueaderos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);

            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);           
        }

        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "reygue28@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "3015267740",
                EmailConfirmed = true,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Agente", ConcurrencyStamp = "2", NormalizedName = "Agente" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }       
    }
}
