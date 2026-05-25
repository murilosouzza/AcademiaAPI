namespace AcademiaAPI.Models
{
    public class Instrutor
    {
        public int IdInstrutor { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public string CREF { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
