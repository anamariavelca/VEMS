using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VEMS.API.Migrations
{
    public partial class SeedCorrectRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("29459ed2-cec3-46fc-a712-d6beb4b42a2c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a38c40da-d3c9-46ce-94ba-b8fe0daa4c62"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("add468b6-1112-4516-8d94-c0a6ce40c3c9"), "bf319a3b-1a6d-48de-b22f-39d020d598d0", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("eb4479e2-4b44-48da-9f5e-262f41f5b94d"), "f141dc80-983d-493b-a5eb-773bcfd976e4", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("add468b6-1112-4516-8d94-c0a6ce40c3c9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eb4479e2-4b44-48da-9f5e-262f41f5b94d"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("29459ed2-cec3-46fc-a712-d6beb4b42a2c"), "6e7458a9-99ed-4072-a39e-cd56ba5c4a68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a38c40da-d3c9-46ce-94ba-b8fe0daa4c62"), "ccb3ed71-ec84-4709-a3f2-a68c05489383", "User", "USER" });
        }
    }
}
