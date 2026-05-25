using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcademiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Instrutores",
                columns: table => new
                {
                    IdInstrutor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Especialidade = table.Column<string>(type: "TEXT", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CREF = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutores", x => x.IdInstrutor);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    IdPlano = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePlano = table.Column<string>(type: "TEXT", nullable: false),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DuracaoMeses = table.Column<int>(type: "INTEGER", nullable: false),
                    IncluiAulasColetivas = table.Column<bool>(type: "INTEGER", nullable: false),
                    IncluiAcompanhamentoNutricional = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.IdPlano);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    IdTurma = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTurma = table.Column<string>(type: "TEXT", nullable: false),
                    Modalidade = table.Column<string>(type: "TEXT", nullable: false),
                    DiaSemana = table.Column<string>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "INTEGER", nullable: false),
                    IdInstrutor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Instrutores_IdInstrutor",
                        column: x => x.IdInstrutor,
                        principalTable: "Instrutores",
                        principalColumn: "IdInstrutor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Situacao = table.Column<string>(type: "TEXT", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPlano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "IdPlano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscricoesTurma",
                columns: table => new
                {
                    IdInscricao_turma = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInscricao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTurma = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricoesTurma", x => x.IdInscricao_turma);
                    table.ForeignKey(
                        name: "FK_InscricoesTurma_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscricoesTurma_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "Ativo", "CPF", "DataNascimento", "Email", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, "111.222.333-44", new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@email.com", "Ana Paula", "14999990001" },
                    { 2, true, "555.666.777-88", new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruno@email.com", "Bruno Costa", "14999990002" }
                });

            migrationBuilder.InsertData(
                table: "Instrutores",
                columns: new[] { "IdInstrutor", "Ativo", "CREF", "DataContratacao", "Email", "Especialidade", "Nome" },
                values: new object[,]
                {
                    { 1, true, "012345-G/SP", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos@academia.com", "Musculação", "Carlos Souza" },
                    { 2, true, "067890-G/SP", new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernanda@academia.com", "Yoga", "Fernanda Lima" }
                });

            migrationBuilder.InsertData(
                table: "Planos",
                columns: new[] { "IdPlano", "Ativo", "DuracaoMeses", "IncluiAcompanhamentoNutricional", "IncluiAulasColetivas", "NomePlano", "ValorMensalidade" },
                values: new object[,]
                {
                    { 1, true, 1, false, false, "Básico", 89.90m },
                    { 2, true, 1, false, true, "Premium", 139.90m },
                    { 3, true, 1, true, true, "VIP", 249.90m }
                });

            migrationBuilder.InsertData(
                table: "Matriculas",
                columns: new[] { "IdMatricula", "DataFim", "DataInicio", "IdAluno", "IdPlano", "Situacao", "ValorPago" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Ativa", 139.90m },
                    { 2, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Ativa", 89.90m }
                });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "IdTurma", "CapacidadeMaxima", "DiaSemana", "Horario", "IdInstrutor", "Modalidade", "NomeTurma" },
                values: new object[,]
                {
                    { 1, 30, "Segunda", new TimeOnly(7, 0, 0), 1, "Musculação", "Musculação Manhã" },
                    { 2, 20, "Quarta", new TimeOnly(14, 0, 0), 2, "Yoga", "Yoga Tarde" }
                });

            migrationBuilder.InsertData(
                table: "InscricoesTurma",
                columns: new[] { "IdInscricao_turma", "Ativo", "DataInscricao", "IdAluno", "IdTurma" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, true, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InscricoesTurma_IdAluno",
                table: "InscricoesTurma",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_InscricoesTurma_IdTurma",
                table: "InscricoesTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdAluno",
                table: "Matriculas",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_IdPlano",
                table: "Matriculas",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdInstrutor",
                table: "Turmas",
                column: "IdInstrutor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscricoesTurma");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Instrutores");
        }
    }
}
