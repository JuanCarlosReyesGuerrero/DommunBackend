using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class RedSocial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedesSociales_Capacity",
                table: "Agentes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978481de-4a57-4c33-ae3c-f438970ea580", "AQAAAAEAACcQAAAAEB6zRLZSg05/BlvTmZlkQG+F0NyKYAh/nHN/0uXdMF/wrH+z5SQr5BqPTpOCaIznIw==", "fcb9d0b6-315b-461f-977d-440f36f7ade7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RedesSociales_Capacity",
                table: "Agentes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15262e6f-3e39-4e54-bfbb-b6ef9b4eff25", "AQAAAAEAACcQAAAAEDmMXrarBP8vUefD2BrNeW6cEBap4vZArpQOvqxXAhgALy8qrRzKATWGp2CYm/rBBA==", "26c3e121-b799-4ce2-92b0-f1b514816635" });
        }
    }
}
