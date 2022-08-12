using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class inmobiliaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Agentes");

            migrationBuilder.AddColumn<int>(
                name: "InmobiliariaId",
                table: "Agentes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inmobiliaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmobiliaria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_InmobiliariaId",
                table: "Agentes",
                column: "InmobiliariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Inmobiliaria_InmobiliariaId",
                table: "Agentes",
                column: "InmobiliariaId",
                principalTable: "Inmobiliaria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Inmobiliaria_InmobiliariaId",
                table: "Agentes");

            migrationBuilder.DropTable(
                name: "Inmobiliaria");

            migrationBuilder.DropIndex(
                name: "IX_Agentes_InmobiliariaId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "InmobiliariaId",
                table: "Agentes");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Agentes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
