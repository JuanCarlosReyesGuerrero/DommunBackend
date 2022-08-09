using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DommunBackend.Data.Migrations
{
    public partial class agente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fecha_inicio_plan",
                table: "Agentes",
                newName: "FechaInicioPlan");

            migrationBuilder.RenameColumn(
                name: "AeptaArriendo",
                table: "Agentes",
                newName: "AceptaArriendo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicioPlan",
                table: "Agentes",
                newName: "fecha_inicio_plan");

            migrationBuilder.RenameColumn(
                name: "AceptaArriendo",
                table: "Agentes",
                newName: "AeptaArriendo");
        }
    }
}
