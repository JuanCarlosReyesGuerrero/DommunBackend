using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class seder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e28eef65-8906-4161-9df6-de2289a5518f", "AQAAAAEAACcQAAAAENqUYRXWOrDyHsNdgtgWvjaUacLawhHD2KQpg2yqyvsN0ZTzrWtrwtuMEeGYBQ22iw==", "b7abc408-0b33-4d97-b405-cbba75ee99c2" });

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.InsertData(
                table: "TipoCaracteristicas",
                columns: new[] { "Id", "Codigo", "CreateUser", "CreatedDate", "IsActive", "ModifiedDate", "ModifiedUser", "Nombre" },
                values: new object[,]
                {
                    { 1, "1", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6665), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Características del exterior" },
                    { 2, "2", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6666), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Características del interior" },
                    { 3, "3", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6668), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Características del sector" }
                });

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.InsertData(
                table: "Caracteristicas",
                columns: new[] { "Id", "Codigo", "CreateUser", "CreatedDate", "IsActive", "ModifiedDate", "ModifiedUser", "Nombre", "TipoCaracteristicaId" },
                values: new object[,]
                {
                    { 1, "1", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6684), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Garaje(s)", 1 },
                    { 2, "2", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6685), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jardín", 1 },
                    { 3, "3", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6686), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sala de internet", 1 },
                    { 4, "4", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6687), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Salón Comunal", 1 },
                    { 5, "5", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6688), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Terraza", 1 },
                    { 6, "6", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6690), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vista panorámica", 1 },
                    { 7, "7", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6691), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vivienda Bifamiliar", 1 },
                    { 8, "8", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6692), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vivienda Multifamiliar", 1 },
                    { 9, "9", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6693), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zonas Verdes", 1 },
                    { 10, "10", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6694), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alarma", 2 },
                    { 11, "11", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6696), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Baño Auxiliar", 2 },
                    { 12, "12", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6698), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cocina Integral", 2 },
                    { 13, "13", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6699), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comedor auxiliar", 2 },
                    { 14, "14", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6700), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cuarto de Servicio", 2 },
                    { 15, "15", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6701), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Depósito / Bodega", 2 },
                    { 16, "16", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6703), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Despensa", 2 },
                    { 17, "17", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6704), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Estudio", 2 },
                    { 18, "18", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6705), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hall de Alcobas", 2 },
                    { 19, "19", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6707), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instalación de gas", 2 },
                    { 20, "20", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6708), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Patio", 2 },
                    { 21, "21", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6709), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Piso en Baldosa / Mármol", 2 },
                    { 22, "22", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6710), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zona de lavandería", 2 },
                    { 23, "23", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6711), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Colegios / Universidades", 3 },
                    { 24, "24", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6713), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Parques cercanos", 3 },
                    { 25, "25", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6714), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sobre vía principal", 3 },
                    { 26, "26", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6715), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Supermercados / C.Comerciales", 3 },
                    { 27, "27", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6716), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trans. Público cercano", 3 },
                    { 28, "28", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6748), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zona Campestre", 3 },
                    { 29, "29", "b74ddd14-6340-4840-95c2-db12554843e5", new DateTime(2022, 8, 19, 22, 18, 43, 803, DateTimeKind.Local).AddTicks(6749), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zona Residencial", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Caracteristicas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TipoCaracteristicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoCaracteristicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoCaracteristicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e27ec7b2-8b95-464f-ba64-c9538d71f5ff", "AQAAAAEAACcQAAAAEKlMh+oqcpqaYS545FJB9gQo7yaH7cqRswy94Zchuf7IHzJptsqwjq44f0IjWftBCw==", "e0b6294a-9e2c-4dd8-8744-8e568e1dcd0b" });

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Estratos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "TipoNegocios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "TipoPropiedades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 19, 22, 2, 28, 140, DateTimeKind.Local).AddTicks(9882));
        }
    }
}
