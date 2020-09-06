using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VEMS.API.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("29459ed2-cec3-46fc-a712-d6beb4b42a2c"), "6e7458a9-99ed-4072-a39e-cd56ba5c4a68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a38c40da-d3c9-46ce-94ba-b8fe0daa4c62"), "ccb3ed71-ec84-4709-a3f2-a68c05489383", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("29459ed2-cec3-46fc-a712-d6beb4b42a2c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a38c40da-d3c9-46ce-94ba-b8fe0daa4c62"));
        }
    }
}
