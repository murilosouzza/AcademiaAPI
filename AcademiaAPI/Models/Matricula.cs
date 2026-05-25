namespace AcademiaAPI.Models;

public class Matricula
{
    public int IdMatricula { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Situacao { get; set; } = string.Empty;
    public decimal ValorPago { get; set; }

    // FKs
    public int IdAluno { get; set; }
    public Aluno Aluno { get; set; } = null!;

    public int IdPlano { get; set; }
    public Plano Plano { get; set; } = null!;
}