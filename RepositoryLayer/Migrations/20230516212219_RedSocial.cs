using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class RedSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b8135209-845a-45b2-98b7-4702db529f69", "AQAAAAEAACcQAAAAEITkWI2fUtx2fGzmE+fV3nGZN3S1brF4QSnZv/843utUo3TGsgnnBI5zw1xWDTlLGw==", "bb1c228a-1b75-45fe-8f6d-d60493092711" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedesSociales_Capacity",
                table: "Agentes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "113da868-9f18-48d7-8be3-d8ca0065c860", "AQAAAAEAACcQAAAAEAWjMbUE09YARvuRel/6JenQjf4jSe9ROtFqYxQamBDHcAzzCGa/3QwGRN+7lw5yMQ==", "fabb1c8c-f8a7-4955-b7fd-04635d4cebeb" });
        }
    }
}
