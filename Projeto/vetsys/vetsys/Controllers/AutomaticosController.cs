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
    public class AutomaticosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public AutomaticosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Automaticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automatico>>> GetAutomatico()
        {
            return await _context.Automatico.ToListAsync();
        }

        // GET: api/Automaticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automatico>> GetAutomatico(Guid id)
        {
            var automatico = await _context.Automatico.FindAsync(id);

            if (automatico == null)
            {
                return NotFound();
            }

            return automatico;
        }

        // PUT: api/Automaticos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomatico(Guid id, Automatico automatico)
        {
            if (id != automatico.AutomaticoId)
            {
                return BadRequest();
            }

            _context.Entry(automatico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomaticoExists(id))
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

        // POST: api/Automaticos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Automatico>> PostAutomatico(Automatico automatico)
        {
            _context.Automatico.Add(automatico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomatico", new { id = automatico.AutomaticoId }, automatico);
        }

        // DELETE: api/Automaticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomatico(Guid id)
        {
            var automatico = await _context.Automatico.FindAsync(id);
            if (automatico == null)
            {
                return NotFound();
            }

            _context.Automatico.Remove(automatico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutomaticoExists(Guid id)
        {
            return _context.Automatico.Any(e => e.AutomaticoId == id);
        }
    }
}
