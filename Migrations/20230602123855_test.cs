using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 2, 14, 38, 55, 511, DateTimeKind.Local).AddTicks(1501));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 6, 2, 11, 28, 3, 379, DateTimeKind.Local).AddTicks(3176));
        }
    }
}
