using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class agentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agente_Municipios_MunicipioId",
                table: "Agente");

            migrationBuilder.DropForeignKey(
                name: "FK_Agente_PlanMembresias_PlanMembresiaId",
                table: "Agente");

            migrationBuilder.DropForeignKey(
                name: "FK_Agente_Zonificaciones_ZonificacionId",
                table: "Agente");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_Agente_AgenteId",
                table: "ZonaDommuns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agente",
                table: "Agente");

            migrationBuilder.RenameTable(
                name: "Agente",
                newName: "Agentes");

            migrationBuilder.RenameIndex(
                name: "IX_Agente_ZonificacionId",
                table: "Agentes",
                newName: "IX_Agentes_ZonificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Agente_PlanMembresiaId",
                table: "Agentes",
                newName: "IX_Agentes_PlanMembresiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Agente_MunicipioId",
                table: "Agentes",
                newName: "IX_Agentes_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Municipios_MunicipioId",
                table: "Agentes",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_PlanMembresias_PlanMembresiaId",
                table: "Agentes",
                column: "PlanMembresiaId",
                principalTable: "PlanMembresias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Zonificaciones_ZonificacionId",
                table: "Agentes",
                column: "ZonificacionId",
                principalTable: "Zonificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Municipios_MunicipioId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_PlanMembresias_PlanMembresiaId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Zonificaciones_ZonificacionId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes");

            migrationBuilder.RenameTable(
                name: "Agentes",
                newName: "Agente");

            migrationBuilder.RenameIndex(
                name: "IX_Agentes_ZonificacionId",
                table: "Agente",
                newName: "IX_Agente_ZonificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Agentes_PlanMembresiaId",
                table: "Agente",
                newName: "IX_Agente_PlanMembresiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Agentes_MunicipioId",
                table: "Agente",
                newName: "IX_Agente_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agente",
                table: "Agente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agente_Municipios_MunicipioId",
                table: "Agente",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agente_PlanMembresias_PlanMembresiaId",
                table: "Agente",
                column: "PlanMembresiaId",
                principalTable: "PlanMembresias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agente_Zonificaciones_ZonificacionId",
                table: "Agente",
                column: "ZonificacionId",
                principalTable: "Zonificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_Agente_AgenteId",
                table: "ZonaDommuns",
                column: "AgenteId",
                principalTable: "Agente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
