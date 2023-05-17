using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class RedSocial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15262e6f-3e39-4e54-bfbb-b6ef9b4eff25", "AQAAAAEAACcQAAAAEDmMXrarBP8vUefD2BrNeW6cEBap4vZArpQOvqxXAhgALy8qrRzKATWGp2CYm/rBBA==", "26c3e121-b799-4ce2-92b0-f1b514816635" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8135209-845a-45b2-98b7-4702db529f69", "AQAAAAEAACcQAAAAEITkWI2fUtx2fGzmE+fV3nGZN3S1brF4QSnZv/843utUo3TGsgnnBI5zw1xWDTlLGw==", "bb1c228a-1b75-45fe-8f6d-d60493092711" });
        }
    }
}
