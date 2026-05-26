using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmasController : ControllerBase
{
    private readonly AcademiaContext _context;

    public TurmasController(AcademiaContext context)
    {
        _context = context;
    }

    // GET: api/turmas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
    {
        return await _context.Turmas
            .Include(t => t.Instrutor)
            .ToListAsync();
    }

    // GET: api/turmas/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Turma>> GetTurma(int id)
    {
        var turma = await _context.Turmas
            .Include(t => t.Instrutor)
            .FirstOrDefaultAsync(t => t.IdTurma == id);

        if (turma == null)
            return NotFound(new { mensagem = "Turma não encontrada" });

        return turma;
    }

    // POST: api/turmas
    [HttpPost]
    public async Task<ActionResult<Turma>> PostTurma(Turma turma)
    {
        _context.Turmas.Add(turma);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTurma), new { id = turma.IdTurma }, turma);
    }

    // PUT: api/turmas/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTurma(int id, Turma turma)
    {
        if (id != turma.IdTurma)
            return BadRequest(new { mensagem = "ID da turma não corresponde" });

        _context.Entry(turma).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Turmas.Any(t => t.IdTurma == id))
                return NotFound(new { mensagem = "Turma não encontrada" });
            throw;
        }

        return NoContent();
    }

    // DELETE: api/turmas/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTurma(int id)
    {
        var turma = await _context.Turmas.FindAsync(id);

        if (turma == null)
            return NotFound(new { mensagem = "Turma não encontrada" });

        _context.Turmas.Remove(turma);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}