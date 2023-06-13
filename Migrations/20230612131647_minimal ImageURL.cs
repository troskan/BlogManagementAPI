using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class minimalImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrl_Posts_PostID",
                table: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ImageUrl",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "ImageUrl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 12, 15, 16, 47, 801, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrl_Posts_PostID",
                table: "ImageUrl",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrl_Posts_PostID",
                table: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ImageUrl",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "ImageUrl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 2, 14, 38, 55, 511, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrl_Posts_PostID",
                table: "ImageUrl",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
