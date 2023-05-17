using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class RedSocial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RedesSociales",
                table: "Agentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e27641b8-04f1-4997-a41b-30543f2f4679", "AQAAAAEAACcQAAAAEMLwD5qkbADKW5LYvF2EC0m9oOLscOQxyBF2RRx9mwbPjJjqYn1sGPGxi0JJrcgJlQ==", "32f44ee7-8d50-44b3-bfb6-c66bfd1400c1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedesSociales",
                table: "Agentes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978481de-4a57-4c33-ae3c-f438970ea580", "AQAAAAEAACcQAAAAEB6zRLZSg05/BlvTmZlkQG+F0NyKYAh/nHN/0uXdMF/wrH+z5SQr5BqPTpOCaIznIw==", "fcb9d0b6-315b-461f-977d-440f36f7ade7" });
        }
    }
}
