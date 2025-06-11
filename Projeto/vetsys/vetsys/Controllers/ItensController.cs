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
    public class ItensController : ControllerBase
    {
        private readonly vetsysContext _context;

        public ItensController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Itens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itens>>> GetItens()
        {
            return await _context.Itens.ToListAsync();
        }

        // GET: api/Itens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itens>> GetItens(Guid id)
        {
            var itens = await _context.Itens.FindAsync(id);

            if (itens == null)
            {
                return NotFound();
            }

            return itens;
        }

        // PUT: api/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItens(Guid id, Itens itens)
        {
            if (id != itens.ItensId)
            {
                return BadRequest();
            }

            _context.Entry(itens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensExists(id))
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

        // POST: api/Itens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itens>> PostItens(Itens itens)
        {
            _context.Itens.Add(itens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItens", new { id = itens.ItensId }, itens);
        }

        // DELETE: api/Itens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItens(Guid id)
        {
            var itens = await _context.Itens.FindAsync(id);
            if (itens == null)
            {
                return NotFound();
            }

            _context.Itens.Remove(itens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensExists(Guid id)
        {
            return _context.Itens.Any(e => e.ItensId == id);
        }
    }
}
