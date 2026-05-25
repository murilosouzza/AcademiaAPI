namespace AcademiaAPI.Models;

public class InscricaoTurma
{
    public int IdInscricao_turma { get; set; }
    public DateTime DataInscricao { get; set; }
    public bool Ativo { get; set; } = true;

    // FKs
    public int IdAluno { get; set; }
    public Aluno Aluno { get; set; } = null!;

    public int IdTurma { get; set; }
    public Turma Turma { get; set; } = null!;
}