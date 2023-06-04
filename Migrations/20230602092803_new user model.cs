using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class newusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 2, 11, 28, 3, 379, DateTimeKind.Local).AddTicks(3176));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 5, 17, 16, 24, 9, 11, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DateRegistered", "Email", "Password", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 17, 16, 24, 9, 11, DateTimeKind.Local).AddTicks(5408), "alvin.strandberg@proton.me", "Billyidol96", 3, "Alvin" },
                    { 2, new DateTime(2023, 5, 17, 16, 24, 9, 11, DateTimeKind.Local).AddTicks(5455), "majanilsson8131@gmail.se", "TrollHealer96", 2, "Maja" }
                });
        }
    }
}
