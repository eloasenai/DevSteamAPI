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
    public class RoedoresController : ControllerBase
    {
        private readonly vetsysContext _context;

        public RoedoresController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Roedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roedores>>> GetRoedores()
        {
            return await _context.Roedores.ToListAsync();
        }

        // GET: api/Roedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roedores>> GetRoedores(Guid id)
        {
            var roedores = await _context.Roedores.FindAsync(id);

            if (roedores == null)
            {
                return NotFound();
            }

            return roedores;
        }

        // PUT: api/Roedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoedores(Guid id, Roedores roedores)
        {
            if (id != roedores.RoedoresId)
            {
                return BadRequest();
            }

            _context.Entry(roedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoedoresExists(id))
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

        // POST: api/Roedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roedores>> PostRoedores(Roedores roedores)
        {
            _context.Roedores.Add(roedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoedores", new { id = roedores.RoedoresId }, roedores);
        }

        // DELETE: api/Roedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoedores(Guid id)
        {
            var roedores = await _context.Roedores.FindAsync(id);
            if (roedores == null)
            {
                return NotFound();
            }

            _context.Roedores.Remove(roedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoedoresExists(Guid id)
        {
            return _context.Roedores.Any(e => e.RoedoresId == id);
        }
    }
}
