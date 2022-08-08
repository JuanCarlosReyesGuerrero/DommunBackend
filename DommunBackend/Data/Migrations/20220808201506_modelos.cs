using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DommunBackend.Data.Migrations
{
    public partial class modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatGestionDocumentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGestionDocumentales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanMembresias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioPromocion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioFijo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMembresias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCaracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCaracteristicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentoPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitoPublicacion = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentoPropiedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoZonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoZonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zonificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestionDocumentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoSubido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    CatGestionDocumentalId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionDocumentales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestionDocumentales_CatGestionDocumentales_CatGestionDocumentalId",
                        column: x => x.CatGestionDocumentalId,
                        principalTable: "CatGestionDocumentales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AplicaApartamento = table.Column<bool>(type: "bit", nullable: false),
                    AplicaCasa = table.Column<bool>(type: "bit", nullable: false),
                    AplicaOficina = table.Column<bool>(type: "bit", nullable: false),
                    AplicaBodega = table.Column<bool>(type: "bit", nullable: false),
                    AplicaLocal = table.Column<bool>(type: "bit", nullable: false),
                    AplicaLote = table.Column<bool>(type: "bit", nullable: false),
                    TipoCaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caracteristicas_TipoCaracteristicas_TipoCaracteristicaId",
                        column: x => x.TipoCaracteristicaId,
                        principalTable: "TipoCaracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoPropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPropiedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoPropiedades_TipoDocumentoPropiedades_TipoDocumentoPropiedadId",
                        column: x => x.TipoDocumentoPropiedadId,
                        principalTable: "TipoDocumentoPropiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoZonaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zonas_TipoZonas_TipoZonaId",
                        column: x => x.TipoZonaId,
                        principalTable: "TipoZonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AeptaArriendo = table.Column<bool>(type: "bit", nullable: false),
                    AceptaVenta = table.Column<bool>(type: "bit", nullable: false),
                    Publicado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioArriendoMin = table.Column<double>(type: "float", nullable: false),
                    PrecioVentaMin = table.Column<double>(type: "float", nullable: false),
                    DescripcionPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroAvaluo = table.Column<int>(type: "int", nullable: false),
                    fecha_inicio_plan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RedesSociales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZonificacionId = table.Column<int>(type: "int", nullable: false),
                    PlanMembresiaId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agentes_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agentes_PlanMembresias_PlanMembresiaId",
                        column: x => x.PlanMembresiaId,
                        principalTable: "PlanMembresias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agentes_Zonificaciones_ZonificacionId",
                        column: x => x.ZonificacionId,
                        principalTable: "Zonificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgenteId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonaDommuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenteId = table.Column<int>(type: "int", nullable: false),
                    TipoZonaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaDommuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZonaDommuns_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                        column: x => x.TipoZonaId,
                        principalTable: "TipoZonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaInmobiliaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dreccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dscripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkVirtual360 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avaluo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    AgenteId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propiedades_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalTable: "Caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propiedades_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propiedades_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comerciales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Espacios = table.Column<int>(type: "int", nullable: false),
                    Cocineta = table.Column<bool>(type: "bit", nullable: false),
                    Banos = table.Column<int>(type: "int", nullable: false),
                    AnioConstruccion = table.Column<int>(type: "int", nullable: false),
                    Balcones = table.Column<int>(type: "int", nullable: false),
                    Terrazas = table.Column<int>(type: "int", nullable: false),
                    AreaPrivada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaConstruida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaTerraza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstacionamientosCubiertos = table.Column<int>(type: "int", nullable: false),
                    EstacionamientosDescubiertos = table.Column<int>(type: "int", nullable: false),
                    EstacionamientosTotales = table.Column<int>(type: "int", nullable: false),
                    Amoblado = table.Column<bool>(type: "bit", nullable: false),
                    Estrato = table.Column<int>(type: "int", nullable: false),
                    Deposito = table.Column<bool>(type: "bit", nullable: false),
                    TipoComercial = table.Column<int>(type: "int", nullable: false),
                    TipoEstacionamientos = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comerciales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comerciales_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FotografiaPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valida = table.Column<bool>(type: "bit", nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiaPropiedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Industriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Espacios = table.Column<int>(type: "int", nullable: false),
                    Banos = table.Column<int>(type: "int", nullable: false),
                    AnioConstruccion = table.Column<int>(type: "int", nullable: false),
                    AreaPrivada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaConstruida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaLote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoBodega = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Industriales_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaLote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoLote = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionComerciales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNegocioComercial = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionComerciales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionComerciales_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionIndustriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNegocioIndustrial = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionIndustriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionIndustriales_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionLotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNegocioLote = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionLotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionLotes_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionViviendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNegocioVivienda = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionViviendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionViviendas_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viviendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habitaciones = table.Column<int>(type: "int", nullable: false),
                    Estudios = table.Column<int>(type: "int", nullable: false),
                    HabitacionesAuxiliares = table.Column<int>(type: "int", nullable: false),
                    Banos = table.Column<int>(type: "int", nullable: false),
                    BanosSociales = table.Column<int>(type: "int", nullable: false),
                    BanosServicio = table.Column<int>(type: "int", nullable: false),
                    AnioConstruccion = table.Column<int>(type: "int", nullable: false),
                    Balcones = table.Column<int>(type: "int", nullable: false),
                    Terrazas = table.Column<int>(type: "int", nullable: false),
                    AreaPrivada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaConstruida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaTerraza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaLote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstacionamientosCubiertos = table.Column<int>(type: "int", nullable: false),
                    EstacionamientosDescubiertos = table.Column<int>(type: "int", nullable: false),
                    EstacionamientosTotales = table.Column<int>(type: "int", nullable: false),
                    Amoblado = table.Column<bool>(type: "bit", nullable: false),
                    Estrato = table.Column<int>(type: "int", nullable: false),
                    Deposito = table.Column<bool>(type: "bit", nullable: false),
                    TipoVivienda = table.Column<int>(type: "int", nullable: false),
                    TipoEstacionamientos = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viviendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viviendas_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Razon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioAdmon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsExclusivo = table.Column<bool>(type: "bit", nullable: false),
                    CertificadoLibTrad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicadoPortales = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmoMotivo = table.Column<bool>(type: "bit", nullable: false),
                    BajoPrecio = table.Column<bool>(type: "bit", nullable: false),
                    Visitas = table.Column<int>(type: "int", nullable: false),
                    AgenteId = table.Column<int>(type: "int", nullable: false),
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false),
                    TipoPublicacion = table.Column<int>(type: "int", nullable: false),
                    PublicacionComercialId = table.Column<int>(type: "int", nullable: true),
                    PublicacionIndustrialId = table.Column<int>(type: "int", nullable: true),
                    PublicacionLoteId = table.Column<int>(type: "int", nullable: true),
                    PublicacionViviendaId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicaciones_PublicacionComerciales_PublicacionComercialId",
                        column: x => x.PublicacionComercialId,
                        principalTable: "PublicacionComerciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicaciones_PublicacionIndustriales_PublicacionIndustrialId",
                        column: x => x.PublicacionIndustrialId,
                        principalTable: "PublicacionIndustriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicaciones_PublicacionLotes_PublicacionLoteId",
                        column: x => x.PublicacionLoteId,
                        principalTable: "PublicacionLotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicaciones_PublicacionViviendas_PublicacionViviendaId",
                        column: x => x.PublicacionViviendaId,
                        principalTable: "PublicacionViviendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_MunicipioId",
                table: "Agentes",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_PlanMembresiaId",
                table: "Agentes",
                column: "PlanMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_ZonificacionId",
                table: "Agentes",
                column: "ZonificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas",
                column: "TipoCaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AgenteId",
                table: "Clientes",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Comerciales_PropiedadId",
                table: "Comerciales",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades",
                column: "TipoDocumentoPropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiaPropiedades_PropiedadId",
                table: "FotografiaPropiedades",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionDocumentales_CatGestionDocumentalId",
                table: "GestionDocumentales",
                column: "CatGestionDocumentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Industriales_PropiedadId",
                table: "Industriales",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_PropiedadId",
                table: "Lotes",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_AgenteId",
                table: "Propiedades",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_CaracteristicaId",
                table: "Propiedades",
                column: "CaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_ClienteId",
                table: "Propiedades",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_MunicipioId",
                table: "Propiedades",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionComerciales_PropiedadId",
                table: "PublicacionComerciales",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_AgenteId",
                table: "Publicaciones",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PublicacionComercialId",
                table: "Publicaciones",
                column: "PublicacionComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PublicacionIndustrialId",
                table: "Publicaciones",
                column: "PublicacionIndustrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PublicacionLoteId",
                table: "Publicaciones",
                column: "PublicacionLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PublicacionViviendaId",
                table: "Publicaciones",
                column: "PublicacionViviendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionIndustriales_PropiedadId",
                table: "PublicacionIndustriales",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionLotes_PropiedadId",
                table: "PublicacionLotes",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionViviendas_PropiedadId",
                table: "PublicacionViviendas",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Viviendas_PropiedadId",
                table: "Viviendas",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZonaDommuns_AgenteId",
                table: "ZonaDommuns",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaDommuns_TipoZonaId",
                table: "ZonaDommuns",
                column: "TipoZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comerciales");

            migrationBuilder.DropTable(
                name: "DocumentoPropiedades");

            migrationBuilder.DropTable(
                name: "FotografiaPropiedades");

            migrationBuilder.DropTable(
                name: "GestionDocumentales");

            migrationBuilder.DropTable(
                name: "Industriales");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Viviendas");

            migrationBuilder.DropTable(
                name: "ZonaDommuns");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "TipoDocumentoPropiedades");

            migrationBuilder.DropTable(
                name: "CatGestionDocumentales");

            migrationBuilder.DropTable(
                name: "PublicacionComerciales");

            migrationBuilder.DropTable(
                name: "PublicacionIndustriales");

            migrationBuilder.DropTable(
                name: "PublicacionLotes");

            migrationBuilder.DropTable(
                name: "PublicacionViviendas");

            migrationBuilder.DropTable(
                name: "TipoZonas");

            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoCaracteristicas");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "PlanMembresias");

            migrationBuilder.DropTable(
                name: "Zonificaciones");
        }
    }
}
