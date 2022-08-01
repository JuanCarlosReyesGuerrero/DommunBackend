using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class reolesuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b114fa-cd35-41f3-aad8-aeb3b89fb18a", "AQAAAAEAACcQAAAAEO965CZ8QZc2h4k9Kt76L3g6X2CLJiHZdGCmLibAonMbX13NQDsvUYVNeI/tFFmTqg==", "441b0b47-aac1-4e29-a8ab-3aba561a5e07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7eda087-becd-4510-b573-515279dddc7b", "AQAAAAEAACcQAAAAEDD65lLoe3RE/W0OulkohnhT/fsS+1dX3YTobOSV2dTiLFR03cJ8XxumoiD/Z62Q6A==", "0038520a-8b28-4e09-bcf4-9d6ca80fc8d2" });
        }
    }
}
