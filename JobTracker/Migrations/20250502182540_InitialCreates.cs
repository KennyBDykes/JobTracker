using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Applications",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId1",
                table: "Applications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId1",
                table: "Applications",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Applications");
        }
    }
}
