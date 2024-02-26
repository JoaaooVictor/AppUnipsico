using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioEmail",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "ConsultaDataRealizacao",
                table: "Consultas",
                newName: "DataConsulta");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioEmail",
                table: "Usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 1,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 19, 11, 46, 338, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 2,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 19, 11, 46, 338, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 3,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 19, 11, 46, 338, DateTimeKind.Local).AddTicks(921));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataConsulta",
                table: "Consultas",
                newName: "ConsultaDataRealizacao");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioEmail",
                table: "Usuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 1,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 24, 2, 9, 40, 407, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 2,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 24, 2, 9, 40, 407, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 3,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 24, 2, 9, 40, 407, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioEmail",
                table: "Usuarios",
                column: "UsuarioEmail",
                unique: true);
        }
    }
}
