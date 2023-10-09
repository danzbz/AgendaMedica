using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMedica.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGM_Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "varchar(400)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DtCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValue: new DateTime(2023, 10, 8, 22, 49, 30, 460, DateTimeKind.Local).AddTicks(9125))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGM_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Crm = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtAgendamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MedicoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PacienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_AGM_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AGM_Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AGM_Paciente",
                columns: new[] { "Id", "Cpf", "DtNascimento", "Nome" },
                values: new object[] { 1, "1234567897", new DateTime(2001, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "DANILO DE PAULA VIEIRA" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_MedicoId",
                table: "Agendamento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "AGM_Paciente");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
