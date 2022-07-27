using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class tipozona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas",
                column: "TipoCaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoPropiedades_TipoDocumentoPropiedadId",
                table: "DocumentoPropiedades",
                column: "TipoDocumentoPropiedadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "DocumentoPropiedades");

            migrationBuilder.DropTable(
                name: "FotografiaPropiedades");

            migrationBuilder.DropTable(
                name: "TipoCaracteristicas");

            migrationBuilder.DropTable(
                name: "TipoDocumentoPropiedades");
        }
    }
}
