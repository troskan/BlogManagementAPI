using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class youtubeurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                columns: new[] { "DatePosted", "YoutubeUrl" },
                values: new object[] { new DateTime(2023, 6, 15, 9, 46, 31, 123, DateTimeKind.Local).AddTicks(8673), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 12, 15, 26, 20, 443, DateTimeKind.Local).AddTicks(6564));
        }
    }
}
