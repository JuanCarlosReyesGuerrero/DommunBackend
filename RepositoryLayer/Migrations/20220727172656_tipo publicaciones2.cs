using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class tipopublicaciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Agentes_AgenteId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_PublicacionComercial_PublicacionComercialId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_PublicacionIndustrial_PublicacionIndustrialId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_PublicacionLote_PublicacionLoteId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_PublicacionVivienda_PublicacionViviendaId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionComercial_Propiedades_PropiedadId",
                table: "PublicacionComercial");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionIndustrial_Propiedades_PropiedadId",
                table: "PublicacionIndustrial");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionLote_Propiedades_PropiedadId",
                table: "PublicacionLote");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionVivienda_Propiedades_PropiedadId",
                table: "PublicacionVivienda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionVivienda",
                table: "PublicacionVivienda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionLote",
                table: "PublicacionLote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionIndustrial",
                table: "PublicacionIndustrial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionComercial",
                table: "PublicacionComercial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacion",
                table: "Publicacion");

            migrationBuilder.RenameTable(
                name: "PublicacionVivienda",
                newName: "PublicacionViviendas");

            migrationBuilder.RenameTable(
                name: "PublicacionLote",
                newName: "PublicacionLotes");

            migrationBuilder.RenameTable(
                name: "PublicacionIndustrial",
                newName: "PublicacionIndustriales");

            migrationBuilder.RenameTable(
                name: "PublicacionComercial",
                newName: "PublicacionComerciales");

            migrationBuilder.RenameTable(
                name: "Publicacion",
                newName: "Publicaciones");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionVivienda_PropiedadId",
                table: "PublicacionViviendas",
                newName: "IX_PublicacionViviendas_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionLote_PropiedadId",
                table: "PublicacionLotes",
                newName: "IX_PublicacionLotes_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionIndustrial_PropiedadId",
                table: "PublicacionIndustriales",
                newName: "IX_PublicacionIndustriales_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionComercial_PropiedadId",
                table: "PublicacionComerciales",
                newName: "IX_PublicacionComerciales_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_PublicacionViviendaId",
                table: "Publicaciones",
                newName: "IX_Publicaciones_PublicacionViviendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_PublicacionLoteId",
                table: "Publicaciones",
                newName: "IX_Publicaciones_PublicacionLoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_PublicacionIndustrialId",
                table: "Publicaciones",
                newName: "IX_Publicaciones_PublicacionIndustrialId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_PublicacionComercialId",
                table: "Publicaciones",
                newName: "IX_Publicaciones_PublicacionComercialId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacion_AgenteId",
                table: "Publicaciones",
                newName: "IX_Publicaciones_AgenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionViviendas",
                table: "PublicacionViviendas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionLotes",
                table: "PublicacionLotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionIndustriales",
                table: "PublicacionIndustriales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionComerciales",
                table: "PublicacionComerciales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionComerciales_Propiedades_PropiedadId",
                table: "PublicacionComerciales",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_Agentes_AgenteId",
                table: "Publicaciones",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_PublicacionComerciales_PublicacionComercialId",
                table: "Publicaciones",
                column: "PublicacionComercialId",
                principalTable: "PublicacionComerciales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_PublicacionIndustriales_PublicacionIndustrialId",
                table: "Publicaciones",
                column: "PublicacionIndustrialId",
                principalTable: "PublicacionIndustriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_PublicacionLotes_PublicacionLoteId",
                table: "Publicaciones",
                column: "PublicacionLoteId",
                principalTable: "PublicacionLotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_PublicacionViviendas_PublicacionViviendaId",
                table: "Publicaciones",
                column: "PublicacionViviendaId",
                principalTable: "PublicacionViviendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionIndustriales_Propiedades_PropiedadId",
                table: "PublicacionIndustriales",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionLotes_Propiedades_PropiedadId",
                table: "PublicacionLotes",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionViviendas_Propiedades_PropiedadId",
                table: "PublicacionViviendas",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionComerciales_Propiedades_PropiedadId",
                table: "PublicacionComerciales");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_Agentes_AgenteId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_PublicacionComerciales_PublicacionComercialId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_PublicacionIndustriales_PublicacionIndustrialId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_PublicacionLotes_PublicacionLoteId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_PublicacionViviendas_PublicacionViviendaId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionIndustriales_Propiedades_PropiedadId",
                table: "PublicacionIndustriales");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionLotes_Propiedades_PropiedadId",
                table: "PublicacionLotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionViviendas_Propiedades_PropiedadId",
                table: "PublicacionViviendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionViviendas",
                table: "PublicacionViviendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionLotes",
                table: "PublicacionLotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionIndustriales",
                table: "PublicacionIndustriales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicacionComerciales",
                table: "PublicacionComerciales");

            migrationBuilder.RenameTable(
                name: "PublicacionViviendas",
                newName: "PublicacionVivienda");

            migrationBuilder.RenameTable(
                name: "PublicacionLotes",
                newName: "PublicacionLote");

            migrationBuilder.RenameTable(
                name: "PublicacionIndustriales",
                newName: "PublicacionIndustrial");

            migrationBuilder.RenameTable(
                name: "Publicaciones",
                newName: "Publicacion");

            migrationBuilder.RenameTable(
                name: "PublicacionComerciales",
                newName: "PublicacionComercial");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionViviendas_PropiedadId",
                table: "PublicacionVivienda",
                newName: "IX_PublicacionVivienda_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionLotes_PropiedadId",
                table: "PublicacionLote",
                newName: "IX_PublicacionLote_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionIndustriales_PropiedadId",
                table: "PublicacionIndustrial",
                newName: "IX_PublicacionIndustrial_PropiedadId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_PublicacionViviendaId",
                table: "Publicacion",
                newName: "IX_Publicacion_PublicacionViviendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_PublicacionLoteId",
                table: "Publicacion",
                newName: "IX_Publicacion_PublicacionLoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_PublicacionIndustrialId",
                table: "Publicacion",
                newName: "IX_Publicacion_PublicacionIndustrialId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_PublicacionComercialId",
                table: "Publicacion",
                newName: "IX_Publicacion_PublicacionComercialId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_AgenteId",
                table: "Publicacion",
                newName: "IX_Publicacion_AgenteId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionComerciales_PropiedadId",
                table: "PublicacionComercial",
                newName: "IX_PublicacionComercial_PropiedadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionVivienda",
                table: "PublicacionVivienda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionLote",
                table: "PublicacionLote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionIndustrial",
                table: "PublicacionIndustrial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacion",
                table: "Publicacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicacionComercial",
                table: "PublicacionComercial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Agentes_AgenteId",
                table: "Publicacion",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_PublicacionComercial_PublicacionComercialId",
                table: "Publicacion",
                column: "PublicacionComercialId",
                principalTable: "PublicacionComercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_PublicacionIndustrial_PublicacionIndustrialId",
                table: "Publicacion",
                column: "PublicacionIndustrialId",
                principalTable: "PublicacionIndustrial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_PublicacionLote_PublicacionLoteId",
                table: "Publicacion",
                column: "PublicacionLoteId",
                principalTable: "PublicacionLote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_PublicacionVivienda_PublicacionViviendaId",
                table: "Publicacion",
                column: "PublicacionViviendaId",
                principalTable: "PublicacionVivienda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionComercial_Propiedades_PropiedadId",
                table: "PublicacionComercial",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionIndustrial_Propiedades_PropiedadId",
                table: "PublicacionIndustrial",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionLote_Propiedades_PropiedadId",
                table: "PublicacionLote",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionVivienda_Propiedades_PropiedadId",
                table: "PublicacionVivienda",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
