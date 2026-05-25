namespace AcademiaAPI.Models
{
    public class Plano
    {
        public int IdPlano { get; set; }
        public string NomePlano { get; set; } = string.Empty;
        public decimal ValorMensalidade { get; set; }
        public int DuracaoMeses { get; set; }
        public bool IncluiAulasColetivas { get; set; }
        public bool IncluiAcompanhamentoNutricional { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
