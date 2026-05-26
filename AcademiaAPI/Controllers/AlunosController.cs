using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly AcademiaContext _context;

    public AlunosController(AcademiaContext context)
    {
        _context = context;
    }

    //Get: api/alunos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
    {
        return await _context.Alunos.ToListAsync();
    }

    //Get: api/alunos/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound(new { mensagem = "Aluno não encontrado" });
        }
        return aluno;
    }

    //Post: api/alunos
    [HttpPost]
    public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.IdAluno }, aluno);
    }

    //put: api/alunos/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAluno(int id, Aluno aluno)
    {
        if (id != aluno.IdAluno)
        {
            return BadRequest(new { mensagem = "ID do aluno não corresponde" });
        }

        _context.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoExists(id))
            {
                return NotFound(new { mensagem = "Aluno não encontrado" });
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    //delete: api/alunos/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound(new { mensagem = "Aluno não encontrado" });
        }

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlunoExists(int id)
    {
        return _context.Alunos.Any(e => e.IdAluno == id);
    }
}