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
    public class CadastrosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public CadastrosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Cadastros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetCadastro()
        {
            return await _context.Cadastro.ToListAsync();
        }

        // GET: api/Cadastros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> GetCadastro(Guid id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return cadastro;
        }

        // PUT: api/Cadastros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastro(Guid id, Cadastro cadastro)
        {
            if (id != cadastro.CadastroId)
            {
                return BadRequest();
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroExists(id))
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

        // POST: api/Cadastros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cadastro>> PostCadastro(Cadastro cadastro)
        {
            _context.Cadastro.Add(cadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastro", new { id = cadastro.CadastroId }, cadastro);
        }

        // DELETE: api/Cadastros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastro(Guid id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroExists(Guid id)
        {
            return _context.Cadastro.Any(e => e.CadastroId == id);
        }
    }
}
