using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class Agendamentodeconsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Users_StudentId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Users_TeacherId",
                table: "Consults");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Users_TeacherId",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Stages_TeacherId",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Consults_StudentId",
                table: "Consults");

            migrationBuilder.DropIndex(
                name: "IX_Consults_TeacherId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Consults");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsultDate",
                table: "Consults",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 1,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 23, 0, 55, 47, 907, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 2,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 23, 0, 55, 47, 907, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "UserTypeModelId",
                keyValue: 3,
                column: "UserTypeDateCreated",
                value: new DateTime(2024, 2, 23, 0, 55, 47, 907, DateTimeKind.Local).AddTicks(7103));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultDate",
                table: "Consults");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Stages",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Consults",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Consults",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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
                name: "IX_Stages_TeacherId",
                table: "Stages",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_StudentId",
                table: "Consults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_TeacherId",
                table: "Consults",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Users_StudentId",
                table: "Consults",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Users_TeacherId",
                table: "Consults",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Users_TeacherId",
                table: "Stages",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
