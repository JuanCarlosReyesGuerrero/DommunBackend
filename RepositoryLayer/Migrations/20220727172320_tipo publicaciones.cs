using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class tipopublicaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicacionComercial",
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
                    table.PrimaryKey("PK_PublicacionComercial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionComercial_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionIndustrial",
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
                    table.PrimaryKey("PK_PublicacionIndustrial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionIndustrial_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionLote",
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
                    table.PrimaryKey("PK_PublicacionLote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionLote_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionVivienda",
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
                    table.PrimaryKey("PK_PublicacionVivienda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionVivienda_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
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
                    table.PrimaryKey("PK_Publicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacion_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicacion_PublicacionComercial_PublicacionComercialId",
                        column: x => x.PublicacionComercialId,
                        principalTable: "PublicacionComercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicacion_PublicacionIndustrial_PublicacionIndustrialId",
                        column: x => x.PublicacionIndustrialId,
                        principalTable: "PublicacionIndustrial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicacion_PublicacionLote_PublicacionLoteId",
                        column: x => x.PublicacionLoteId,
                        principalTable: "PublicacionLote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicacion_PublicacionVivienda_PublicacionViviendaId",
                        column: x => x.PublicacionViviendaId,
                        principalTable: "PublicacionVivienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_AgenteId",
                table: "Publicacion",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_PublicacionComercialId",
                table: "Publicacion",
                column: "PublicacionComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_PublicacionIndustrialId",
                table: "Publicacion",
                column: "PublicacionIndustrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_PublicacionLoteId",
                table: "Publicacion",
                column: "PublicacionLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_PublicacionViviendaId",
                table: "Publicacion",
                column: "PublicacionViviendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionComercial_PropiedadId",
                table: "PublicacionComercial",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionIndustrial_PropiedadId",
                table: "PublicacionIndustrial",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionLote_PropiedadId",
                table: "PublicacionLote",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionVivienda_PropiedadId",
                table: "PublicacionVivienda",
                column: "PropiedadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropTable(
                name: "PublicacionComercial");

            migrationBuilder.DropTable(
                name: "PublicacionIndustrial");

            migrationBuilder.DropTable(
                name: "PublicacionLote");

            migrationBuilder.DropTable(
                name: "PublicacionVivienda");
        }
    }
}
