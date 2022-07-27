﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220726010648_GestionDocumental")]
    partial class GestionDocumental
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Models.Agente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AceptaVenta")
                        .HasColumnType("bit");

                    b.Property<bool>("AeptaArriendo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroAvaluo")
                        .HasColumnType("int");

                    b.Property<int>("PlanMembresiaId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioArriendoMin")
                        .HasColumnType("float");

                    b.Property<double>("PrecioVentaMin")
                        .HasColumnType("float");

                    b.Property<bool>("Publicado")
                        .HasColumnType("bit");

                    b.Property<string>("RedesSociales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZonificacionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_inicio_plan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PlanMembresiaId");

                    b.HasIndex("ZonificacionId");

                    b.ToTable("Agentes");
                });

            modelBuilder.Entity("DomainLayer.Models.CatGestionDocumental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatGestionDocumentales");
                });

            modelBuilder.Entity("DomainLayer.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("DomainLayer.Models.GestionDocumental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentoSubido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("GestionDocumentales");
                });

            modelBuilder.Entity("DomainLayer.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("DomainLayer.Models.PlanMembresia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioFijo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecioPromocion")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PlanMembresias");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoZona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoZonas");
                });

            modelBuilder.Entity("DomainLayer.Models.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoZonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoZonaId");

                    b.ToTable("Zonas");
                });

            modelBuilder.Entity("DomainLayer.Models.ZonaDommun", b =>
                {
                    b.Property<int>("AgenteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoZonaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AgenteId", "TipoZonaId");

                    b.HasIndex("TipoZonaId");

                    b.ToTable("ZonaDommuns");
                });

            modelBuilder.Entity("DomainLayer.Models.Zonificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zonificaciones");
                });

            modelBuilder.Entity("DomainLayer.Models.Agente", b =>
                {
                    b.HasOne("DomainLayer.Models.Municipio", "Municipio")
                        .WithMany("Agentes")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.PlanMembresia", "PlanMembresia")
                        .WithMany("Agentes")
                        .HasForeignKey("PlanMembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Zonificacion", "Zonificacion")
                        .WithMany("Agentes")
                        .HasForeignKey("ZonificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("PlanMembresia");

                    b.Navigation("Zonificacion");
                });

            modelBuilder.Entity("DomainLayer.Models.GestionDocumental", b =>
                {
                    b.HasOne("DomainLayer.Models.CatGestionDocumental", "CatGestionDocumental")
                        .WithMany("GestionDocumentales")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatGestionDocumental");
                });

            modelBuilder.Entity("DomainLayer.Models.Municipio", b =>
                {
                    b.HasOne("DomainLayer.Models.Departamento", "Departamento")
                        .WithMany("Municipios")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("DomainLayer.Models.Zona", b =>
                {
                    b.HasOne("DomainLayer.Models.TipoZona", "TipoZona")
                        .WithMany("Zonas")
                        .HasForeignKey("TipoZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoZona");
                });

            modelBuilder.Entity("DomainLayer.Models.ZonaDommun", b =>
                {
                    b.HasOne("DomainLayer.Models.Agente", "Agente")
                        .WithMany("ZonaDommuns")
                        .HasForeignKey("AgenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.TipoZona", "TipoZona")
                        .WithMany("ZonaDommuns")
                        .HasForeignKey("TipoZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agente");

                    b.Navigation("TipoZona");
                });

            modelBuilder.Entity("DomainLayer.Models.Agente", b =>
                {
                    b.Navigation("ZonaDommuns");
                });

            modelBuilder.Entity("DomainLayer.Models.CatGestionDocumental", b =>
                {
                    b.Navigation("GestionDocumentales");
                });

            modelBuilder.Entity("DomainLayer.Models.Departamento", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("DomainLayer.Models.Municipio", b =>
                {
                    b.Navigation("Agentes");
                });

            modelBuilder.Entity("DomainLayer.Models.PlanMembresia", b =>
                {
                    b.Navigation("Agentes");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoZona", b =>
                {
                    b.Navigation("ZonaDommuns");

                    b.Navigation("Zonas");
                });

            modelBuilder.Entity("DomainLayer.Models.Zonificacion", b =>
                {
                    b.Navigation("Agentes");
                });
#pragma warning restore 612, 618
        }
    }
}
