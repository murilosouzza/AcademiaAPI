using System.Text.Json.Serialization;

namespace AcademiaAPI.Models;

public class Matricula
{
    public int IdMatricula { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Situacao { get; set; } = string.Empty;
    public decimal ValorPago { get; set; }

    public int IdAluno { get; set; }
    [JsonIgnore]
    public Aluno? Aluno { get; set; }

    public int IdPlano { get; set; }
    [JsonIgnore]
    public Plano? Plano { get; set; }
}