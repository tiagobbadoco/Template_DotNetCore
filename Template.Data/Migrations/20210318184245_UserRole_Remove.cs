using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class UserRole_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b7e4ea45-541a-4917-8d43-e0673eb9056b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e94383f0-931b-483c-b8fc-b48d38fa829d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0153f3b-1a00-4194-ae05-141248e38cf4"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UsersRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("e94383f0-931b-483c-b8fc-b48d38fa829d"), new DateTime(2021, 3, 18, 14, 59, 39, 72, DateTimeKind.Local).AddTicks(2107), null, false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { new Guid("b7e4ea45-541a-4917-8d43-e0673eb9056b"), new DateTime(2021, 3, 18, 14, 59, 39, 72, DateTimeKind.Local).AddTicks(2160), null, false, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name", "Password" },
                values: new object[] { new Guid("a0153f3b-1a00-4194-ae05-141248e38cf4"), new DateTime(2021, 3, 18, 14, 59, 39, 70, DateTimeKind.Local).AddTicks(7423), null, "admin@template.com", false, "Administrador", "Template" });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "RoleId", "UserId" },
                values: new object[] { new Guid("26a597b7-4b48-4045-b7c4-557aeccc6558"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new Guid("e94383f0-931b-483c-b8fc-b48d38fa829d"), new Guid("a0153f3b-1a00-4194-ae05-141248e38cf4") });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId_RoleId",
                table: "UsersRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }
    }
}
