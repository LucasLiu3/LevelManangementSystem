using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LevelManangementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37057c2a-51d0-4f19-8851-1e09d756b579", null, "Supervisor", "SUPERVISOR" },
                    { "b15f564c-202a-451c-babb-a0efb93289db", null, "Admin", "ADMIN" },
                    { "ed1b69bc-4aed-4616-9181-0beb1731b9c9", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df", 0, "32c375dd-8989-495b-b335-58f0517900c7", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECXfgtaF/mHRAmIiB9y4Ur6xr7cyxdgu2n3gVbzFnRa7XDpck4buXb9+x9fIs91lZg==", null, false, "1e2a72b2-7b0c-4d22-b167-ff83d2c96890", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b15f564c-202a-451c-babb-a0efb93289db", "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37057c2a-51d0-4f19-8851-1e09d756b579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1b69bc-4aed-4616-9181-0beb1731b9c9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b15f564c-202a-451c-babb-a0efb93289db", "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15f564c-202a-451c-babb-a0efb93289db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df");
        }
    }
}
