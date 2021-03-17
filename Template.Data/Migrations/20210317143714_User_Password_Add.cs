using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class User_Password_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49224089-f669-4894-a169-d750ad3ee113"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name", "Password" },
                values: new object[] { new Guid("dcf9f9c5-ef5b-468b-a838-d9c0875855bf"), new DateTime(2021, 3, 17, 11, 37, 13, 734, DateTimeKind.Local).AddTicks(6542), null, "admin@template.com", false, "Administrador", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dcf9f9c5-ef5b-468b-a838-d9c0875855bf"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name" },
                values: new object[] { new Guid("49224089-f669-4894-a169-d750ad3ee113"), new DateTime(2021, 3, 16, 16, 8, 26, 971, DateTimeKind.Local).AddTicks(7519), null, "admin@template.com", false, "Administrador" });
        }
    }
}
