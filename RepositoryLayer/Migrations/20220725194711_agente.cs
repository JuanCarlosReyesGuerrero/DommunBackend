using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class agente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Agente",
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
                    table.PrimaryKey("PK_Agente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agente_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agente_PlanMembresias_PlanMembresiaId",
                        column: x => x.PlanMembresiaId,
                        principalTable: "PlanMembresias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agente_Zonificaciones_ZonificacionId",
                        column: x => x.ZonificacionId,
                        principalTable: "Zonificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZonaDommuns",
                columns: table => new
                {
                    AgenteId = table.Column<int>(type: "int", nullable: false),
                    TipoZonaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaDommuns", x => new { x.AgenteId, x.TipoZonaId });
                    table.ForeignKey(
                        name: "FK_ZonaDommuns_Agente_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                        column: x => x.TipoZonaId,
                        principalTable: "TipoZonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agente_MunicipioId",
                table: "Agente",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_PlanMembresiaId",
                table: "Agente",
                column: "PlanMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_ZonificacionId",
                table: "Agente",
                column: "ZonificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaDommuns_TipoZonaId",
                table: "ZonaDommuns",
                column: "TipoZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZonaDommuns");

            migrationBuilder.DropTable(
                name: "Agente");

            migrationBuilder.DropTable(
                name: "Zonificaciones");
        }
    }
}
