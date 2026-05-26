using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Models;

namespace AcademiaAPI.Data;

public class AcademiaContext : DbContext
{
    public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Instrutor> Instrutores { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }
    public DbSet<InscricaoTurma> InscricoesTurma { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Chaves primárias
        modelBuilder.Entity<Aluno>().HasKey(a => a.IdAluno);
        modelBuilder.Entity<Plano>().HasKey(p => p.IdPlano);
        modelBuilder.Entity<Instrutor>().HasKey(i => i.IdInstrutor);
        modelBuilder.Entity<Turma>().HasKey(t => t.IdTurma);
        modelBuilder.Entity<Matricula>().HasKey(m => m.IdMatricula);
        modelBuilder.Entity<InscricaoTurma>().HasKey(i => i.IdInscricao_turma);

        // Relacionamentos
        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Aluno)
            .WithMany(a => a.Matriculas)
            .HasForeignKey(m => m.IdAluno);

        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Plano)
            .WithMany(p => p.Matriculas)
            .HasForeignKey(m => m.IdPlano);

        modelBuilder.Entity<Turma>()
            .HasOne(t => t.Instrutor)
            .WithMany(i => i.Turmas)
            .HasForeignKey(t => t.IdInstrutor);

        modelBuilder.Entity<InscricaoTurma>()
            .HasOne(it => it.Aluno)
            .WithMany(a => a.InscricoesTurma)
            .HasForeignKey(it => it.IdAluno);

        modelBuilder.Entity<InscricaoTurma>()
            .HasOne(it => it.Turma)
            .WithMany(t => t.InscricoesTurma)
            .HasForeignKey(it => it.IdTurma);

        // Precisão decimal
        modelBuilder.Entity<Plano>()
            .Property(p => p.ValorMensalidade)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Matricula>()
            .Property(m => m.ValorPago)
            .HasColumnType("decimal(10,2)");

        // Seed de dados
        modelBuilder.Entity<Plano>().HasData(
            new Plano { IdPlano = 1, NomePlano = "Básico", ValorMensalidade = 89.90m, DuracaoMeses = 1, IncluiAulasColetivas = false, IncluiAcompanhamentoNutricional = false, Ativo = true },
            new Plano { IdPlano = 2, NomePlano = "Premium", ValorMensalidade = 139.90m, DuracaoMeses = 1, IncluiAulasColetivas = true, IncluiAcompanhamentoNutricional = false, Ativo = true },
            new Plano { IdPlano = 3, NomePlano = "VIP", ValorMensalidade = 249.90m, DuracaoMeses = 1, IncluiAulasColetivas = true, IncluiAcompanhamentoNutricional = true, Ativo = true }
        );

        modelBuilder.Entity<Instrutor>().HasData(
            new Instrutor { IdInstrutor = 1, Nome = "Carlos Souza", Email = "carlos@academia.com", Especialidade = "Musculação", CREF = "012345-G/SP", DataContratacao = new DateTime(2020, 1, 10), Ativo = true },
            new Instrutor { IdInstrutor = 2, Nome = "Fernanda Lima", Email = "fernanda@academia.com", Especialidade = "Yoga", CREF = "067890-G/SP", DataContratacao = new DateTime(2021, 3, 5), Ativo = true }
        );

        modelBuilder.Entity<Aluno>().HasData(
            new Aluno { IdAluno = 1, Nome = "Ana Paula", CPF = "111.222.333-44", Email = "ana@email.com", Telefone = "14999990001", DataNascimento = new DateTime(1995, 3, 10), Ativo = true },
            new Aluno { IdAluno = 2, Nome = "Bruno Costa", CPF = "555.666.777-88", Email = "bruno@email.com", Telefone = "14999990002", DataNascimento = new DateTime(1990, 7, 22), Ativo = true }
        );

        modelBuilder.Entity<Turma>().HasData(
            new Turma { IdTurma = 1, NomeTurma = "Musculação Manhã", Modalidade = "Musculação", DiaSemana = "Segunda", Horario = "07:00:00", CapacidadeMaxima = 30, IdInstrutor = 1 },
            new Turma { IdTurma = 2, NomeTurma = "Yoga Tarde", Modalidade = "Yoga", DiaSemana = "Quarta", Horario = "14:00:00", CapacidadeMaxima = 20, IdInstrutor = 2 }
        );

        modelBuilder.Entity<Matricula>().HasData(
            new Matricula { IdMatricula = 1, DataInicio = new DateTime(2025, 1, 5), DataFim = new DateTime(2025, 12, 5), Situacao = "Ativa", ValorPago = 139.90m, IdAluno = 1, IdPlano = 2 },
            new Matricula { IdMatricula = 2, DataInicio = new DateTime(2025, 2, 10), DataFim = new DateTime(2025, 12, 10), Situacao = "Ativa", ValorPago = 89.90m, IdAluno = 2, IdPlano = 1 }
        );

        modelBuilder.Entity<InscricaoTurma>().HasData(
            new InscricaoTurma { IdInscricao_turma = 1, DataInscricao = new DateTime(2025, 1, 6), Ativo = true, IdAluno = 1, IdTurma = 1 },
            new InscricaoTurma { IdInscricao_turma = 2, DataInscricao = new DateTime(2025, 2, 11), Ativo = true, IdAluno = 2, IdTurma = 2 }
        );
    }
}