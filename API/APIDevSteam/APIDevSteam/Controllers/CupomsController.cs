using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDevSteam.Data;
using APIDevSteam.Models;

namespace APIDevSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomsController : ControllerBase
    {
        private readonly APIContext _context;

        public CupomsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cupoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cupom>>> GetCupom()
        {
            return await _context.Cupom.ToListAsync();
        }

        // GET: api/Cupoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cupom>> GetCupom(Guid id)
        {
            var cupom = await _context.Cupom.FindAsync(id);

            if (cupom == null)
            {
                return NotFound();
            }

            return cupom;
        }

        // PUT: api/Cupoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupom(Guid id, Cupom cupom)
        {
            if (id != cupom.CupomId)
            {
                return BadRequest();
            }

            _context.Entry(cupom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CupomExists(id))
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

        // POST: api/Cupoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cupom>> PostCupom(Cupom cupom)
        {




            _context.Cupom.Add(cupom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupom", new { id = cupom.CupomId }, cupom);
        }

        // DELETE: api/Cupoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupom(Guid id)
        {
            var cupom = await _context.Cupom.FindAsync(id);
            if (cupom == null)
            {
                return NotFound();
            }

            _context.Cupom.Remove(cupom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupomExists(Guid id)
        {
            return _context.Cupom.Any(e => e.CupomId == id);
        }
    }
}
