using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class UserRole_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bce1308e-d9ec-4313-8a1e-c39e0edeffa5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d146f554-a691-4fa1-a412-d3a5b573597e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e80724dc-1307-4ea9-b262-ec268fb4f1ef"));

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("4f081924-94f1-4a8d-8448-185e983a42a1"), new DateTime(2021, 3, 18, 16, 8, 43, 312, DateTimeKind.Local).AddTicks(7685), null, false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("f13e90df-6fec-440e-aa72-73b18c558435"), new DateTime(2021, 3, 18, 16, 8, 43, 312, DateTimeKind.Local).AddTicks(7740), null, false, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name", "Password" },
                values: new object[] { new Guid("a62e3cf4-7352-414f-a835-d73fa7787a05"), new DateTime(2021, 3, 18, 16, 8, 43, 311, DateTimeKind.Local).AddTicks(5611), null, "admin@template.com", false, "Administrador", "Template" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "RoleId", "UserId" },
                values: new object[] { new Guid("32385c3b-326c-4a3f-9f3e-a698d4815a2c"), new DateTime(2021, 3, 18, 16, 8, 43, 314, DateTimeKind.Local).AddTicks(621), null, false, new Guid("4f081924-94f1-4a8d-8448-185e983a42a1"), new Guid("a62e3cf4-7352-414f-a835-d73fa7787a05") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_RoleId",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f13e90df-6fec-440e-aa72-73b18c558435"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4f081924-94f1-4a8d-8448-185e983a42a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a62e3cf4-7352-414f-a835-d73fa7787a05"));

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("bce1308e-d9ec-4313-8a1e-c39e0edeffa5"), new DateTime(2021, 3, 18, 15, 42, 44, 965, DateTimeKind.Local).AddTicks(3986), null, false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("d146f554-a691-4fa1-a412-d3a5b573597e"), new DateTime(2021, 3, 18, 15, 42, 44, 965, DateTimeKind.Local).AddTicks(4040), null, false, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name", "Password" },
                values: new object[] { new Guid("e80724dc-1307-4ea9-b262-ec268fb4f1ef"), new DateTime(2021, 3, 18, 15, 42, 44, 964, DateTimeKind.Local).AddTicks(1653), null, "admin@template.com", false, "Administrador", "Template" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }
    }
}
