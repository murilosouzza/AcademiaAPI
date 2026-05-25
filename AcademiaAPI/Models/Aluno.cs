namespace AcademiaAPI.Models;

public class Aluno
{
	public int IdAluno { get; set; }

	public string Nome { get; set; } = string.Empty;

	public string CPF { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string Telefone { get; set; } = string.Empty;

	public DateTime DataNascimento { get; set; }

	public bool Ativo { get; set; } = true;

	
	public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

	public ICollection<InscricaoTurma> InscricoesTurma { get; set; } = new List<InscricaoTurma>();
}