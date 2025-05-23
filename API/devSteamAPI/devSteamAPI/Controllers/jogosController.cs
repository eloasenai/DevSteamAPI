﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using devSteamAPI.Data;
using devSteamAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace DevSteamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly DevSteamAPIContext _context;

        public JogosController(DevSteamAPIContext context)
        {
            _context = context;
        }

        // GET: api/Jogos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<jogo>>> GetJogos()
        {
            return await _context.Jogos.ToListAsync();
        }

        // GET: api/Jogos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<jogo>> GetJogo(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return jogo;
        }

        // GET: api/Jogos/ByName
        [HttpGet("ByName")]
        public async Task<ActionResult<IEnumerable<jogo>>> GetJogosByName(string name)
        {
            var jogos = await _context.Jogos
                .Where(j => j.Nome.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            if (jogos == null || !jogos.Any())
            {
                return NotFound();
            }

            return jogos;
        }

        // PUT: api/Jogos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogo(Guid id, jogo jogo)
        {
            if (id != jogo.JogoId)
            {
                return BadRequest();
            }

            _context.Entry(jogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoExists(id))
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

        // POST: api/Jogos
        [HttpPost]
        public async Task<ActionResult<jogo>> PostJogo(jogo jogo)
        {
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = jogo.JogoId }, jogo);
        }

        // DELETE: api/Jogos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogoExists(Guid id)
        {
            return _context.Jogos.Any(e => e.JogoId == id);
        }
    }
}
