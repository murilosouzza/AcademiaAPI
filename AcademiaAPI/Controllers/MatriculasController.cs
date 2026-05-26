using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly AcademiaContext _context;

    public MatriculasController(AcademiaContext context)
    {
        _context = context;
    }

    // GET: api/matriculas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
    {
        return await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Plano)
            .ToListAsync();
    }

    // GET: api/matriculas/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Matricula>> GetMatricula(int id)
    {
        var matricula = await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Plano)
            .FirstOrDefaultAsync(m => m.IdMatricula == id);

        if (matricula == null)
            return NotFound(new { mensagem = "Matrícula não encontrada" });

        return matricula;
    }

    // POST: api/matriculas
    [HttpPost]
    public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMatricula), new { id = matricula.IdMatricula }, matricula);
    }

    // PUT: api/matriculas/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
    {
        if (id != matricula.IdMatricula)
            return BadRequest(new { mensagem = "ID da matrícula não corresponde" });

        _context.Entry(matricula).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Matriculas.Any(m => m.IdMatricula == id))
                return NotFound(new { mensagem = "Matrícula não encontrada" });
            throw;
        }

        return NoContent();
    }

    // DELETE: api/matriculas/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatricula(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);

        if (matricula == null)
            return NotFound(new { mensagem = "Matrícula não encontrada" });

        _context.Matriculas.Remove(matricula);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}