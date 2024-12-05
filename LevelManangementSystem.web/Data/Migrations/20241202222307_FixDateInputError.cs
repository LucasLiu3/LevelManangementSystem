using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelManangementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDateInputError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId1",
                table: "leaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId1",
                table: "leaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_leaveRequests_EmployeeId1",
                table: "leaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_leaveRequests_ReviewerId1",
                table: "leaveRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "leaveRequests");

            migrationBuilder.DropColumn(
                name: "ReviewerId1",
                table: "leaveRequests");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "leaveRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "leaveRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6d91efa-9767-4d00-8392-558f4af4f1fc", "AQAAAAIAAYagAAAAEExjtL/wGZlkkGXXfx9MFcf4p1xCT/b3OJp92MH15iZQoNy5NTudxj699DBmljXBvg==", "298dca6e-d9f1-4ce8-9c4a-ee20073b5491" });

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_EmployeeId",
                table: "leaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_ReviewerId",
                table: "leaveRequests",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId",
                table: "leaveRequests",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId",
                table: "leaveRequests",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId",
                table: "leaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId",
                table: "leaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_leaveRequests_EmployeeId",
                table: "leaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_leaveRequests_ReviewerId",
                table: "leaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "leaveRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "leaveRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "leaveRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId1",
                table: "leaveRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0f2163b-d2ed-45b7-b513-129aca36d38f", "AQAAAAIAAYagAAAAEPiaxUMxw7KiTme4Ct0m81v1TBNj/Tka65eg1/wIQNqqD2au1vrGfSj0+xYgl3xKoA==", "c2c23b95-b74d-498c-8a87-6e82326de1eb" });

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_EmployeeId1",
                table: "leaveRequests",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_ReviewerId1",
                table: "leaveRequests",
                column: "ReviewerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_EmployeeId1",
                table: "leaveRequests",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_AspNetUsers_ReviewerId1",
                table: "leaveRequests",
                column: "ReviewerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
