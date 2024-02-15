using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConfigUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 1,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 15, 0, 18, 0, 440, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 2,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 15, 0, 18, 0, 440, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 3,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 15, 0, 18, 0, 440, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeModelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 1,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 2,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 3,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
