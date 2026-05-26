using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrutoresController : ControllerBase
{
    private readonly AcademiaContext _context;

    public InstrutoresController(AcademiaContext context)
    {
        _context = context;
    }

    // GET: api/instrutores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instrutor>>> GetInstrutores()
    {
        return await _context.Instrutores.ToListAsync();
    }

    // GET: api/instrutores/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Instrutor>> GetInstrutor(int id)
    {
        var instrutor = await _context.Instrutores.FindAsync(id);

        if (instrutor == null)
            return NotFound(new { mensagem = "Instrutor não encontrado" });

        return instrutor;
    }

    // POST: api/instrutores
    [HttpPost]
    public async Task<ActionResult<Instrutor>> PostInstrutor(Instrutor instrutor)
    {
        _context.Instrutores.Add(instrutor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInstrutor), new { id = instrutor.IdInstrutor }, instrutor);
    }

    // PUT: api/instrutores/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInstrutor(int id, Instrutor instrutor)
    {
        if (id != instrutor.IdInstrutor)
            return BadRequest(new { mensagem = "ID do instrutor não corresponde" });

        _context.Entry(instrutor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Instrutores.Any(i => i.IdInstrutor == id))
                return NotFound(new { mensagem = "Instrutor não encontrado" });
            throw;
        }

        return NoContent();
    }

    // DELETE: api/instrutores/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstrutor(int id)
    {
        var instrutor = await _context.Instrutores.FindAsync(id);

        if (instrutor == null)
            return NotFound(new { mensagem = "Instrutor não encontrado" });

        _context.Instrutores.Remove(instrutor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}