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
    public class SacolasController : ControllerBase
    {
        private readonly vetsysContext _context;

        public SacolasController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Sacolas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sacola>>> GetSacola()
        {
            return await _context.Sacola.ToListAsync();
        }

        // GET: api/Sacolas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sacola>> GetSacola(Guid id)
        {
            var sacola = await _context.Sacola.FindAsync(id);

            if (sacola == null)
            {
                return NotFound();
            }

            return sacola;
        }

        // PUT: api/Sacolas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSacola(Guid id, Sacola sacola)
        {
            if (id != sacola.SacolaId)
            {
                return BadRequest();
            }

            _context.Entry(sacola).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacolaExists(id))
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

        // POST: api/Sacolas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sacola>> PostSacola(Sacola sacola)
        {
            _context.Sacola.Add(sacola);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSacola", new { id = sacola.SacolaId }, sacola);
        }

        // DELETE: api/Sacolas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSacola(Guid id)
        {
            var sacola = await _context.Sacola.FindAsync(id);
            if (sacola == null)
            {
                return NotFound();
            }

            _context.Sacola.Remove(sacola);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SacolaExists(Guid id)
        {
            return _context.Sacola.Any(e => e.SacolaId == id);
        }
    }
}
