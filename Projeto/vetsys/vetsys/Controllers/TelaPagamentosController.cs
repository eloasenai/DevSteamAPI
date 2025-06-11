using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vetsys.Data;
using vetsys.Models;

namespace vetsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelaPagamentosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public TelaPagamentosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/TelaPagamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelaPagamento>>> GetTelaPagamento()
        {
            return await _context.TelaPagamento.ToListAsync();
        }

        // GET: api/TelaPagamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelaPagamento>> GetTelaPagamento(Guid id)
        {
            var telaPagamento = await _context.TelaPagamento.FindAsync(id);

            if (telaPagamento == null)
            {
                return NotFound();
            }

            return telaPagamento;
        }

        // PUT: api/TelaPagamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelaPagamento(Guid id, TelaPagamento telaPagamento)
        {
            if (id != telaPagamento.TelaPagamentoId)
            {
                return BadRequest();
            }

            _context.Entry(telaPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelaPagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TelaPagamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TelaPagamento>> PostTelaPagamento(TelaPagamento telaPagamento)
        {
            _context.TelaPagamento.Add(telaPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelaPagamento", new { id = telaPagamento.TelaPagamentoId }, telaPagamento);
        }

        // DELETE: api/TelaPagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelaPagamento(Guid id)
        {
            var telaPagamento = await _context.TelaPagamento.FindAsync(id);
            if (telaPagamento == null)
            {
                return NotFound();
            }

            _context.TelaPagamento.Remove(telaPagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelaPagamentoExists(Guid id)
        {
            return _context.TelaPagamento.Any(e => e.TelaPagamentoId == id);
        }
    }
}
