using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class Configurandodatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConsulta",
                table: "Consultas");

            migrationBuilder.AddColumn<Guid>(
                name: "DataConsultaId",
                table: "Consultas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "DatasConsultas",
                columns: table => new
                {
                    DataConsultaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataConsulta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasConsultas", x => x.DataConsultaId);
                    table.ForeignKey(
                        name: "FK_DatasConsultas_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "ConsultaId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_DatasConsultas_ConsultaId",
                table: "DatasConsultas",
                column: "ConsultaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatasConsultas");

            migrationBuilder.DropColumn(
                name: "DataConsultaId",
                table: "Consultas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConsulta",
                table: "Consultas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
