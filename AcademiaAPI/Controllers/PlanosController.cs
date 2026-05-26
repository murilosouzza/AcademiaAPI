using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanosController : ControllerBase
{
    private readonly AcademiaContext _context;

    public PlanosController(AcademiaContext context)
    {
        _context = context;
    }

    // GET: api/planos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plano>>> GetPlanos()
    {
        return await _context.Planos.ToListAsync();
    }

    // GET: api/planos/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Plano>> GetPlano(int id)
    {
        var plano = await _context.Planos.FindAsync(id);

        if (plano == null)
            return NotFound(new { mensagem = "Plano não encontrado" });

        return plano;
    }

    // POST: api/planos
    [HttpPost]
    public async Task<ActionResult<Plano>> PostPlano(Plano plano)
    {
        _context.Planos.Add(plano);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlano), new { id = plano.IdPlano }, plano);
    }

    // PUT: api/planos/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlano(int id, Plano plano)
    {
        if (id != plano.IdPlano)
            return BadRequest(new { mensagem = "ID do plano não corresponde" });

        _context.Entry(plano).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Planos.Any(p => p.IdPlano == id))
                return NotFound(new { mensagem = "Plano não encontrado" });
            throw;
        }

        return NoContent();
    }

    // DELETE: api/planos/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlano(int id)
    {
        var plano = await _context.Planos.FindAsync(id);

        if (plano == null)
            return NotFound(new { mensagem = "Plano não encontrado" });

        _context.Planos.Remove(plano);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}