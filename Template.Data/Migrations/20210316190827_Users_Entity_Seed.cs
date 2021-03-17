using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class Users_Entity_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8bee4f7d-217e-4791-a413-5d5cc4bfaeca"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name" },
                values: new object[] { new Guid("49224089-f669-4894-a169-d750ad3ee113"), new DateTime(2021, 3, 16, 16, 8, 26, 971, DateTimeKind.Local).AddTicks(7519), null, "admin@template.com", false, "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49224089-f669-4894-a169-d750ad3ee113"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name" },
                values: new object[] { new Guid("8bee4f7d-217e-4791-a413-5d5cc4bfaeca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@template.com", false, "Administrador" });
        }
    }
}
