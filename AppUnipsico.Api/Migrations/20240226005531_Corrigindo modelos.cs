using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class Corrigindomodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioSenha",
                table: "Usuarios",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "UsuarioEmail",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UsuarioDataRegistro",
                table: "Usuarios",
                newName: "DataRegistro");

            migrationBuilder.RenameColumn(
                name: "UsuarioDataNascimento",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "UsuarioCpf",
                table: "Usuarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "UsuarioAtivo",
                table: "Usuarios",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_UsuarioCpf",
                table: "Usuarios",
                newName: "IX_Usuarios_Cpf");

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 1,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 21, 55, 31, 136, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 2,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 21, 55, 31, 136, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "TiposUsuarios",
                keyColumn: "TipoUsuarioId",
                keyValue: 3,
                column: "TipoUsuarioDataRegistro",
                value: new DateTime(2024, 2, 25, 21, 55, 31, 136, DateTimeKind.Local).AddTicks(8254));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "UsuarioSenha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "UsuarioNome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "UsuarioEmail");

            migrationBuilder.RenameColumn(
                name: "DataRegistro",
                table: "Usuarios",
                newName: "UsuarioDataRegistro");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Usuarios",
                newName: "UsuarioDataNascimento");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios",
                newName: "UsuarioCpf");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Usuarios",
                newName: "UsuarioAtivo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                newName: "IX_Usuarios_UsuarioCpf");

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
    }
}
