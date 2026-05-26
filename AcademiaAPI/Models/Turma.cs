using System.Text.Json.Serialization;

namespace AcademiaAPI.Models;

public class Turma
{
    public int IdTurma { get; set; }
    public string NomeTurma { get; set; } = string.Empty;
    public string Modalidade { get; set; } = string.Empty;
    public string DiaSemana { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
    public int CapacidadeMaxima { get; set; }

    public int IdInstrutor { get; set; }
    public Instrutor? Instrutor { get; set; }

    [JsonIgnore]
    public ICollection<InscricaoTurma> InscricoesTurma { get; set; } = new List<InscricaoTurma>();
}