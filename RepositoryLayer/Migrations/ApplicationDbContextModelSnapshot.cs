﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("DomainLayer.Models.Caracteristica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AplicaApartamento")
                        .HasColumnType("bit");

                    b.Property<bool>("AplicaBodega")
                        .HasColumnType("bit");

                    b.Property<bool>("AplicaCasa")
                        .HasColumnType("bit");

                    b.Property<bool>("AplicaLocal")
                        .HasColumnType("bit");

                    b.Property<bool>("AplicaLote")
                        .HasColumnType("bit");

                    b.Property<bool>("AplicaOficina")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoCaracteristicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoCaracteristicaId");

                    b.ToTable("Caracteristicas");
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

            modelBuilder.Entity("DomainLayer.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgenteId")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoPrincipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoSecundario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.ToTable("Clientes");
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

            modelBuilder.Entity("DomainLayer.Models.DocumentoPropiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropiedadId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDocumentoPropiedadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoDocumentoPropiedadId");

                    b.ToTable("DocumentoPropiedades");
                });

            modelBuilder.Entity("DomainLayer.Models.FotografiaPropiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EsPrincipal")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<int>("PropiedadId")
                        .HasColumnType("int");

                    b.Property<bool>("Valida")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PropiedadId");

                    b.ToTable("FotografiaPropiedades");
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

            modelBuilder.Entity("DomainLayer.Models.Propiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenteId")
                        .HasColumnType("int");

                    b.Property<string>("Avaluo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CaracteristicaId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Coordenadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dreccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dscripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkVirtual360")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatriculaInmobiliaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.HasIndex("CaracteristicaId");

                    b.ToTable("Propiedades");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoCaracteristica", b =>
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

                    b.ToTable("TipoCaracteristicas");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoDocumentoPropiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequisitoPublicacion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentoPropiedades");
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

            modelBuilder.Entity("DomainLayer.Models.Caracteristica", b =>
                {
                    b.HasOne("DomainLayer.Models.TipoCaracteristica", "TipoCaracteristica")
                        .WithMany("Caracteristicas")
                        .HasForeignKey("TipoCaracteristicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCaracteristica");
                });

            modelBuilder.Entity("DomainLayer.Models.Cliente", b =>
                {
                    b.HasOne("DomainLayer.Models.Agente", "Agente")
                        .WithMany("Clientes")
                        .HasForeignKey("AgenteId");

                    b.Navigation("Agente");
                });

            modelBuilder.Entity("DomainLayer.Models.DocumentoPropiedad", b =>
                {
                    b.HasOne("DomainLayer.Models.TipoDocumentoPropiedad", "TipoDocumentoPropiedad")
                        .WithMany("DocumentoPropiedades")
                        .HasForeignKey("TipoDocumentoPropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocumentoPropiedad");
                });

            modelBuilder.Entity("DomainLayer.Models.FotografiaPropiedad", b =>
                {
                    b.HasOne("DomainLayer.Models.Propiedad", "Propiedad")
                        .WithMany("FotografiaPropiedades")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propiedad");
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

            modelBuilder.Entity("DomainLayer.Models.Propiedad", b =>
                {
                    b.HasOne("DomainLayer.Models.Agente", "Agente")
                        .WithMany("Propiedades")
                        .HasForeignKey("AgenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Caracteristica", "Caracteristica")
                        .WithMany("Propiedades")
                        .HasForeignKey("CaracteristicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agente");

                    b.Navigation("Caracteristica");
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
                    b.Navigation("Clientes");

                    b.Navigation("Propiedades");

                    b.Navigation("ZonaDommuns");
                });

            modelBuilder.Entity("DomainLayer.Models.Caracteristica", b =>
                {
                    b.Navigation("Propiedades");
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

            modelBuilder.Entity("DomainLayer.Models.Propiedad", b =>
                {
                    b.Navigation("FotografiaPropiedades");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoCaracteristica", b =>
                {
                    b.Navigation("Caracteristicas");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoDocumentoPropiedad", b =>
                {
                    b.Navigation("DocumentoPropiedades");
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
