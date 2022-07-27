using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class muni_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Caracteristicas_TipoCaracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoPropiedades_TipoDocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionDocumentales_CatGestionDocumentales_CategoriaId",
                table: "GestionDocumentales");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Agentes_AgenteId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                table: "ZonaDommuns");

            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_MunicipioId",
                table: "Propiedades",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Municipios_MunicipioId",
                table: "Agentes",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_PlanMembresias_PlanMembresiaId",
                table: "Agentes",
                column: "PlanMembresiaId",
                principalTable: "PlanMembresias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Zonificaciones_ZonificacionId",
                table: "Agentes",
                column: "ZonificacionId",
                principalTable: "Zonificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Caracteristicas_TipoCaracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas",
                column: "TipoCaracteristicaId",
                principalTable: "TipoCaracteristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoPropiedades_TipoDocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades",
                column: "TipoDocumentoPropiedadId",
                principalTable: "TipoDocumentoPropiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GestionDocumentales_CatGestionDocumentales_CategoriaId",
                table: "GestionDocumentales",
                column: "CategoriaId",
                principalTable: "CatGestionDocumentales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Agentes_AgenteId",
                table: "Propiedades",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                table: "Propiedades",
                column: "CaracteristicaId",
                principalTable: "Caracteristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Municipios_MunicipioId",
                table: "Propiedades",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                table: "ZonaDommuns",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Caracteristicas_TipoCaracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoPropiedades_TipoDocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionDocumentales_CatGestionDocumentales_CategoriaId",
                table: "GestionDocumentales");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Agentes_AgenteId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Municipios_MunicipioId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                table: "ZonaDommuns");

            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas");

            migrationBuilder.DropIndex(
                name: "IX_Propiedades_MunicipioId",
                table: "Propiedades");

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
                name: "FK_Caracteristicas_TipoCaracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas",
                column: "TipoCaracteristicaId",
                principalTable: "TipoCaracteristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agentes_AgenteId",
                table: "Clientes",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoPropiedades_TipoDocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades",
                column: "TipoDocumentoPropiedadId",
                principalTable: "TipoDocumentoPropiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiaPropiedades_Propiedades_PropiedadId",
                table: "FotografiaPropiedades",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GestionDocumentales_CatGestionDocumentales_CategoriaId",
                table: "GestionDocumentales",
                column: "CategoriaId",
                principalTable: "CatGestionDocumentales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Agentes_AgenteId",
                table: "Propiedades",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Caracteristicas_CaracteristicaId",
                table: "Propiedades",
                column: "CaracteristicaId",
                principalTable: "Caracteristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Clientes_ClienteId",
                table: "Propiedades",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_Agentes_AgenteId",
                table: "ZonaDommuns",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZonaDommuns_TipoZonas_TipoZonaId",
                table: "ZonaDommuns",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
