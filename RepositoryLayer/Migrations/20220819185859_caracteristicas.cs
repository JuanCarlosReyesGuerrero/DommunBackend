using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class caracteristicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Garages",
                table: "Propiedades",
                newName: "Piso");

            migrationBuilder.RenameColumn(
                name: "Dormitorios",
                table: "Propiedades",
                newName: "Parqueaderos");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Propiedades",
                newName: "Habitaciones");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPropiedadId",
                table: "Propiedades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoPropiedadId",
                table: "Propiedades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "Propiedades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgenteId",
                table: "Propiedades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Administracion",
                table: "Propiedades",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Antiguedad",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaConstruida",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaPrivada",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstratoId",
                table: "Propiedades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecioMetro",
                table: "Propiedades",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TipoNegocioId",
                table: "Propiedades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estratos", x => x.Id);
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
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCaracteristicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNegocios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    CaracteristicaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaPropiedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaracteristicaPropiedades_Caracteristicas_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalTable: "Caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaracteristicaPropiedades_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4de4c2ab-7423-4929-9ded-ac01095be162", "AQAAAAEAACcQAAAAEDHiJZ4bqh5TolV4wxgySM9EkoLCyNefr6TkFj2pjhy6ObBzmKnB4mkIosrTTlWonA==", "d643df03-8118-4152-b966-6efe87e31796" });

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_EstratoId",
                table: "Propiedades",
                column: "EstratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_TipoNegocioId",
                table: "Propiedades",
                column: "TipoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaPropiedades_CaracteristicaId",
                table: "CaracteristicaPropiedades",
                column: "CaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaPropiedades_PropiedadId",
                table: "CaracteristicaPropiedades",
                column: "PropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_TipoCaracteristicaId",
                table: "Caracteristicas",
                column: "TipoCaracteristicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_Estratos_EstratoId",
                table: "Propiedades",
                column: "EstratoId",
                principalTable: "Estratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propiedades_TipoNegocios_TipoNegocioId",
                table: "Propiedades",
                column: "TipoNegocioId",
                principalTable: "TipoNegocios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_Estratos_EstratoId",
                table: "Propiedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Propiedades_TipoNegocios_TipoNegocioId",
                table: "Propiedades");

            migrationBuilder.DropTable(
                name: "CaracteristicaPropiedades");

            migrationBuilder.DropTable(
                name: "Estratos");

            migrationBuilder.DropTable(
                name: "TipoNegocios");

            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "TipoCaracteristicas");

            migrationBuilder.DropIndex(
                name: "IX_Propiedades_EstratoId",
                table: "Propiedades");

            migrationBuilder.DropIndex(
                name: "IX_Propiedades_TipoNegocioId",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "Administracion",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "Antiguedad",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "AreaConstruida",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "AreaPrivada",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "EstratoId",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "PrecioMetro",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "TipoNegocioId",
                table: "Propiedades");

            migrationBuilder.RenameColumn(
                name: "Piso",
                table: "Propiedades",
                newName: "Garages");

            migrationBuilder.RenameColumn(
                name: "Parqueaderos",
                table: "Propiedades",
                newName: "Dormitorios");

            migrationBuilder.RenameColumn(
                name: "Habitaciones",
                table: "Propiedades",
                newName: "Area");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPropiedadId",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoPropiedadId",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgenteId",
                table: "Propiedades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f3edc1f-0c84-40a2-9fb0-8c70dd8c69e8", "AQAAAAEAACcQAAAAEAxlfCTwQaeJiNpS3ROo+DR9HxEFX2yBybd418n1FTobp7tF0DkHi+oEwNutdQ++aA==", "21d7bac8-dbe8-4106-b2ac-39311f28afd2" });
        }
    }
}
