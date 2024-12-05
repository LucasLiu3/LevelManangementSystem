using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelManangementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4488def0-791c-4a27-8453-c5d8605dd963", new DateOnly(1987, 3, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEDAL70zFJ7wyR6+0QR6e2V27LNa7url/NCVONgBl6SBkmNwVaAr1gDmgtrCzWCIWZA==", "2fcc638c-b286-4936-8294-6d9272ad9382" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32c375dd-8989-495b-b335-58f0517900c7", "AQAAAAIAAYagAAAAECXfgtaF/mHRAmIiB9y4Ur6xr7cyxdgu2n3gVbzFnRa7XDpck4buXb9+x9fIs91lZg==", "1e2a72b2-7b0c-4d22-b167-ff83d2c96890" });
        }
    }
}
