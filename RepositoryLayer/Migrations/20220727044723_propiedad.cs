using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class propiedad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "AgenteId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalTable: "Caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotografiaPropiedades_PropiedadId",
                table: "FotografiaPropiedades",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_AgenteId",
                table: "Propiedades",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_CaracteristicaId",
                table: "Propiedades",
                column: "CaracteristicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades");

            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropIndex(
                name: "IX_FotografiaPropiedades_PropiedadId",
                table: "FotografiaPropiedades");

            migrationBuilder.AlterColumn<int>(
                name: "AgenteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
