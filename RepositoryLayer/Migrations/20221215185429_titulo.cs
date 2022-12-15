using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class titulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Propiedades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f0d539a-1492-4208-ad82-98cb43a21385", "AQAAAAEAACcQAAAAEB28KCKY7UXrXKjkmcle0ptU2Ew9M1sQVDrQBiHj0B8h0Z15gqfUDTyO54uGPugFrQ==", "877b3d90-03b2-4872-be7e-b9122464a182" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Propiedades");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0428da93-efdf-4fa4-a08c-285c08a265b6", "AQAAAAEAACcQAAAAEJ68rEgG45IofET6DqyTdcrsfgJc0SlzCHK7zmVnOnq+pswgsMwVkmSBucqWrq+yVQ==", "00aa3278-732b-438e-bc8f-c30932af9f97" });
        }
    }
}
