using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turmas",
                keyColumn: "IdTurma",
                keyValue: 1,
                column: "Horario",
                value: "07:00:00");

            migrationBuilder.UpdateData(
                table: "Turmas",
                keyColumn: "IdTurma",
                keyValue: 2,
                column: "Horario",
                value: "14:00:00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turmas",
                keyColumn: "IdTurma",
                keyValue: 1,
                column: "Horario",
                value: new TimeOnly(7, 0, 0));

            migrationBuilder.UpdateData(
                table: "Turmas",
                keyColumn: "IdTurma",
                keyValue: 2,
                column: "Horario",
                value: new TimeOnly(14, 0, 0));
        }
    }
}
