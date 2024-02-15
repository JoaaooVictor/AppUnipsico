using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppUnipsico.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PublicPlace = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Neighborhood = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Town = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserTypeDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserTypeDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserTypeIsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeModelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InstitutionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                    table.ForeignKey(
                        name: "FK_Institutions_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserDisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserDateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCpf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEmail = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeModelId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consults",
                columns: table => new
                {
                    ConsultId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ConsultStatus = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consults", x => x.ConsultId);
                    table.ForeignKey(
                        name: "FK_Consults_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consults_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consults_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateStage = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InstitutionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_Stages_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stages_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stages_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeModelId", "UserTypeDateCreated", "UserTypeDescription", "UserTypeIsAdmin", "UserTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4614), "Paciente do consultório", false, "Paciente" },
                    { 2, new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4630), "Aluno de Psicologia", false, "Aluno" },
                    { 3, new DateTime(2024, 2, 13, 23, 22, 42, 390, DateTimeKind.Local).AddTicks(4632), "Professor e Admin", true, "Professor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consults_PatientId",
                table: "Consults",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_StudentId",
                table: "Consults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_TeacherId",
                table: "Consults",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_AddressId",
                table: "Institutions",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_InstitutionId",
                table: "Stages",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_StudentId",
                table: "Stages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_TeacherId",
                table: "Stages",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCpf",
                table: "Users",
                column: "UserCpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consults");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
