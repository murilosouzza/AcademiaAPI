using System.Text.Json.Serialization;

namespace AcademiaAPI.Models;

public class InscricaoTurma
{
    public int IdInscricao_turma { get; set; }
    public DateTime DataInscricao { get; set; }
    public bool Ativo { get; set; } = true;

    public int IdAluno { get; set; }
    [JsonIgnore]
    public Aluno? Aluno { get; set; }

    public int IdTurma { get; set; }
    [JsonIgnore]
    public Turma? Turma { get; set; }
}