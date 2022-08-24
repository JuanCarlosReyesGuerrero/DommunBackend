using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class titulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Propiedades");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df7baea-9351-487e-8203-55f578c3e7ba", "AQAAAAEAACcQAAAAEFlKMPBbQuQwFPANKy4IgH3aPFQ0dzjkQjQVAAgUagspkoiARrfnLUG0l+P3vHTVlQ==", "4e862513-4509-43f2-b21b-8e21881ccb0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Propiedades",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83df2b8d-5070-415e-b88e-a4bf9bef712b", "AQAAAAEAACcQAAAAEGDNMVGL33HByldvX+HdQZYLQ0XD98XPc71uN09rRvVhlBqKAibfwl5KiVFt2AxJyw==", "fcff0042-d687-4883-b0dc-b107f4acc569" });
        }
    }
}
