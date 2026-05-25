# 🏋️ AcademiaAPI

API RESTful para gerenciamento de academia de ginástica, desenvolvida com **ASP.NET Core 10**, **Entity Framework Core** e **SQLite**.

## 👥 Equipe
- Murilo Souza
- Samara Balura
- Raul Brandão
- Carla Regina

## 🎯 Sobre o Projeto
Sistema de gerenciamento de academia que permite controlar alunos, planos de mensalidade, instrutores, turmas e matrículas. Desenvolvido como trabalho prático da disciplina de Plataforma de Desenvolvimento de Software — ADS 3ºC.

## 🗂️ Entidades
| Entidade | Descrição |
|---|---|
| Aluno | Dados cadastrais dos alunos |
| Plano | Planos de mensalidade disponíveis |
| Instrutor | Profissionais que ministram as turmas |
| Turma | Aulas oferecidas com horário e modalidade |
| Matrícula | Registro de matrícula do aluno em um plano |
| InscricaoTurma | Inscrição do aluno em uma turma (N:M) |

## 🔗 Relacionamentos
- **Plano 1:N Matrícula** — Um plano pode ter várias matrículas
- **Aluno 1:N Matrícula** — Um aluno pode ter várias matrículas
- **Instrutor 1:N Turma** — Um instrutor ministra várias turmas
- **Aluno N:M Turma** — Via tabela InscricaoTurma

## 🚀 Como Rodar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Passos
```bash
# Restaurar pacotes
dotnet restore

# Criar migration
dotnet ef migrations add InitialCreate

# Rodar o projeto (migrations e seed aplicados automaticamente)
dotnet run
```

Acesse o Swagger em: `http://localhost:5245/swagger`

## 🗄️ Banco de Dados
SQLite — o arquivo `academia.db` é criado automaticamente na raiz do projeto ao rodar pela primeira vez, já com dados de seed.

## 📦 Pacotes Utilizados
| Pacote | Versão |
|---|---|
| Microsoft.EntityFrameworkCore.Sqlite | 10.0.8 |
| Microsoft.EntityFrameworkCore.Design | 10.0.8 |
| Swashbuckle.AspNetCore | 10.1.7 |

## 📋 Sprints
| Sprint | Foco | Deadline |
|---|---|---|
| Sprint 1 | Modelagem e banco | 26/05/2026 |
| Sprint 2 | CRUD e endpoints | 09/06/2026 |
| Sprint 3 | Apresentação | 16/06/2026 |
