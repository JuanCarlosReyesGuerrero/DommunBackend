using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class usuarios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "5afac875-aceb-4b3a-bf6a-16ff2a957c0d", "reygue28@gmail.com", true, "AQAAAAEAACcQAAAAEOIiMZrh9iVulzaP8YR8ey8q0B8TkF7L5O/mQNHGz14/TChrSTJpwa3oWXoWGc3IgQ==", "3015267740", "14454e0c-50df-4e9f-a51c-eebecc8ff188" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "438346dd-b89b-4193-8cf0-e6c80a8fa967", "admin@gmail.com", false, null, "1234567890", "d38e5619-2585-4d0e-987d-ea02b53be25d" });
        }
    }
}
