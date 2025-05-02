using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("48a81dff-664b-43d4-811c-8281975f718d"), "applicant123", "Applicant", "applicant" },
                    { new Guid("c8ae333b-aec2-4729-b5f3-799b5197accd"), "admin123", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("48a81dff-664b-43d4-811c-8281975f718d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8ae333b-aec2-4729-b5f3-799b5197accd"));
        }
    }
}
