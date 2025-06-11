using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;
using vetsys.Data;

namespace vetsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public GatosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Gatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gato>>> GetGato()
        {
            return await _context.Gato.ToListAsync();
        }

        // GET: api/Gatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gato>> GetGato(Guid id)
        {
            var gato = await _context.Gato.FindAsync(id);

            if (gato == null)
            {
                return NotFound();
            }

            return gato;
        }

        // PUT: api/Gatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGato(Guid id, Gato gato)
        {
            if (id != gato.GatoId)
            {
                return BadRequest();
            }

            _context.Entry(gato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatoExists(id))
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

        // POST: api/Gatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gato>> PostGato(Gato gato)
        {
            _context.Gato.Add(gato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGato", new { id = gato.GatoId }, gato);
        }

        // DELETE: api/Gatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGato(Guid id)
        {
            var gato = await _context.Gato.FindAsync(id);
            if (gato == null)
            {
                return NotFound();
            }

            _context.Gato.Remove(gato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GatoExists(Guid id)
        {
            return _context.Gato.Any(e => e.GatoId == id);
        }
    }
}
