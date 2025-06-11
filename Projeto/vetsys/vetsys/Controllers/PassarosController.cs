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
    public class PassarosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public PassarosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Passaros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passaros>>> GetPassaros()
        {
            return await _context.Passaros.ToListAsync();
        }

        // GET: api/Passaros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passaros>> GetPassaros(Guid id)
        {
            var passaros = await _context.Passaros.FindAsync(id);

            if (passaros == null)
            {
                return NotFound();
            }

            return passaros;
        }

        // PUT: api/Passaros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassaros(Guid id, Passaros passaros)
        {
            if (id != passaros.PassarosId)
            {
                return BadRequest();
            }

            _context.Entry(passaros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassarosExists(id))
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

        // POST: api/Passaros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passaros>> PostPassaros(Passaros passaros)
        {
            _context.Passaros.Add(passaros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassaros", new { id = passaros.PassarosId }, passaros);
        }

        // DELETE: api/Passaros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassaros(Guid id)
        {
            var passaros = await _context.Passaros.FindAsync(id);
            if (passaros == null)
            {
                return NotFound();
            }

            _context.Passaros.Remove(passaros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassarosExists(Guid id)
        {
            return _context.Passaros.Any(e => e.PassarosId == id);
        }
    }
}
