using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaAPI.Data;
using AcademiaAPI.Models;

namespace AcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InscricoesTurmaController : ControllerBase
{
    private readonly AcademiaContext _context;

    public InscricoesTurmaController(AcademiaContext context)
    {
        _context = context;
    }

    // GET: api/inscricoesturma
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoTurma>>> GetInscricoes()
    {
        return await _context.InscricoesTurma
            .Include(it => it.Aluno)
            .Include(it => it.Turma)
            .ToListAsync();
    }

    // GET: api/inscricoesturma/1
    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoTurma>> GetInscricao(int id)
    {
        var inscricao = await _context.InscricoesTurma
            .Include(it => it.Aluno)
            .Include(it => it.Turma)
            .FirstOrDefaultAsync(it => it.IdInscricao_turma == id);

        if (inscricao == null)
            return NotFound(new { mensagem = "Inscrição não encontrada" });

        return inscricao;
    }

    // POST: api/inscricoesturma
    [HttpPost]
    public async Task<ActionResult<InscricaoTurma>> PostInscricao(InscricaoTurma inscricao)
    {
        _context.InscricoesTurma.Add(inscricao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInscricao), new { id = inscricao.IdInscricao_turma }, inscricao);
    }

    // PUT: api/inscricoesturma/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInscricao(int id, InscricaoTurma inscricao)
    {
        if (id != inscricao.IdInscricao_turma)
            return BadRequest(new { mensagem = "ID da inscrição não corresponde" });

        _context.Entry(inscricao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.InscricoesTurma.Any(it => it.IdInscricao_turma == id))
                return NotFound(new { mensagem = "Inscrição não encontrada" });
            throw;
        }

        return NoContent();
    }

    // DELETE: api/inscricoesturma/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInscricao(int id)
    {
        var inscricao = await _context.InscricoesTurma.FindAsync(id);

        if (inscricao == null)
            return NotFound(new { mensagem = "Inscrição não encontrada" });

        _context.InscricoesTurma.Remove(inscricao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}