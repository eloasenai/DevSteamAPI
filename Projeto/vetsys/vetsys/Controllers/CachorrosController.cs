﻿using System;
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
    public class CachorrosController : ControllerBase
    {
        private readonly vetsysContext _context;

        public CachorrosController(vetsysContext context)
        {
            _context = context;
        }

        // GET: api/Cachorros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cachorro>>> GetCachorro()
        {
            return await _context.Cachorro.ToListAsync();
        }

        // GET: api/Cachorros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cachorro>> GetCachorro(Guid id)
        {
            var cachorro = await _context.Cachorro.FindAsync(id);

            if (cachorro == null)
            {
                return NotFound();
            }

            return cachorro;
        }

        // PUT: api/Cachorros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCachorro(Guid id, Cachorro cachorro)
        {
            if (id != cachorro.CachorroId)
            {
                return BadRequest();
            }

            _context.Entry(cachorro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CachorroExists(id))
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

        // POST: api/Cachorros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cachorro>> PostCachorro(Cachorro cachorro)
        {
            _context.Cachorro.Add(cachorro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCachorro", new { id = cachorro.CachorroId }, cachorro);
        }

        // DELETE: api/Cachorros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCachorro(Guid id)
        {
            var cachorro = await _context.Cachorro.FindAsync(id);
            if (cachorro == null)
            {
                return NotFound();
            }

            _context.Cachorro.Remove(cachorro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CachorroExists(Guid id)
        {
            return _context.Cachorro.Any(e => e.CachorroId == id);
        }
    }
}
