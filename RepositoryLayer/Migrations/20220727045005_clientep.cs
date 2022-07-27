using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class clientep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_ClienteId",
                table: "Propiedades",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades");

            migrationBuilder.DropIndex(
                name: "IX_Propiedades_ClienteId",
                table: "Propiedades");
        }
    }
}
