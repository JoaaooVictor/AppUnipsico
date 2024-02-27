using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstagioId",
                table: "Usuarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Ra",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 1,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 27, 8, 52, 52, 62, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 2,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 27, 8, 52, 52, 62, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 3,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 27, 8, 52, 52, 62, DateTimeKind.Local).AddTicks(8545));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstagioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ra",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 1,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 26, 2, 58, 27, 142, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 2,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 26, 2, 58, 27, 142, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 3,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 26, 2, 58, 27, 142, DateTimeKind.Local).AddTicks(1707));
        }
    }
}
