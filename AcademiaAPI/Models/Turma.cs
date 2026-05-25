using System.Globalization;

namespace AcademiaAPI.Models
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; } = string.Empty;
        public string Modalidade { get; set; } = string.Empty; 

        public String DiaSemana { get; set; } = string.Empty;
        public TimeOnly Horario { get; set; }
        public int CapacidadeMaxima { get; set; }

        // FK
        public int IdInstrutor { get; set; }
        public Instrutor Instrutor { get; set; } = null!;

        public ICollection<InscricaoTurma> InscricoesTurma { get; set; } = new List<InscricaoTurma>();
    }
}
