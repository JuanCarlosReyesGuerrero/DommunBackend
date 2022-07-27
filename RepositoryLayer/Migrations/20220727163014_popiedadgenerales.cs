using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class popiedadgenerales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Amoblado",
                table: "Viviendas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AnioConstruccion",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaConstruida",
                table: "Viviendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaLote",
                table: "Viviendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaPrivada",
                table: "Viviendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaTerraza",
                table: "Viviendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Balcones",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Banos",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BanosServicio",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BanosSociales",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deposito",
                table: "Viviendas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosCubiertos",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosDescubiertos",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosTotales",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estrato",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Habitaciones",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionesAuxiliares",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Terrazas",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoEstacionamientos",
                table: "Viviendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnioConstruccion",
                table: "Industriales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaConstruida",
                table: "Industriales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaLote",
                table: "Industriales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaPrivada",
                table: "Industriales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Banos",
                table: "Industriales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Amoblado",
                table: "Comerciales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AnioConstruccion",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaConstruida",
                table: "Comerciales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaPrivada",
                table: "Comerciales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaTerraza",
                table: "Comerciales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Balcones",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Banos",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Cocineta",
                table: "Comerciales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deposito",
                table: "Comerciales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosCubiertos",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosDescubiertos",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstacionamientosTotales",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estrato",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Terrazas",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoEstacionamientos",
                table: "Comerciales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amoblado",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AnioConstruccion",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AreaConstruida",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AreaLote",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AreaPrivada",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AreaTerraza",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Balcones",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Banos",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "BanosServicio",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "BanosSociales",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Deposito",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "EstacionamientosCubiertos",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "EstacionamientosDescubiertos",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "EstacionamientosTotales",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Estrato",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Habitaciones",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "HabitacionesAuxiliares",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "Terrazas",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "TipoEstacionamientos",
                table: "Viviendas");

            migrationBuilder.DropColumn(
                name: "AnioConstruccion",
                table: "Industriales");

            migrationBuilder.DropColumn(
                name: "AreaConstruida",
                table: "Industriales");

            migrationBuilder.DropColumn(
                name: "AreaLote",
                table: "Industriales");

            migrationBuilder.DropColumn(
                name: "AreaPrivada",
                table: "Industriales");

            migrationBuilder.DropColumn(
                name: "Banos",
                table: "Industriales");

            migrationBuilder.DropColumn(
                name: "Amoblado",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "AnioConstruccion",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "AreaConstruida",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "AreaPrivada",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "AreaTerraza",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Balcones",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Banos",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Cocineta",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Deposito",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "EstacionamientosCubiertos",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "EstacionamientosDescubiertos",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "EstacionamientosTotales",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Estrato",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "Terrazas",
                table: "Comerciales");

            migrationBuilder.DropColumn(
                name: "TipoEstacionamientos",
                table: "Comerciales");
        }
    }
}
