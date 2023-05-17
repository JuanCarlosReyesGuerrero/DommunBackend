using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class quitaredessociales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedesSociales",
                table: "Agentes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ea6c987-bf69-4be6-8dff-6406a5869694", "AQAAAAEAACcQAAAAENkd3brcXm+aIrLUqdeXd7XWUgLE5El1UdFB/n8YhUAAkZDW/hNgadi6w/gK/tLlzw==", "0c090dce-d39b-44ac-b3b6-46d143db736d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
