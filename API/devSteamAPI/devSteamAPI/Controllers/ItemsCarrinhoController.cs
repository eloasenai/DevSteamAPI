using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using devSteamAPI.Data;
using devSteamAPI.Models;

namespace devSteamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsCarrinhoController : ControllerBase
    {
        private readonly DevSteamAPIContext _context;

        public ItemsCarrinhoController(DevSteamAPIContext context)
        {
            _context = context;
        }

        // GET: api/ItemsCarrinho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCarrinho>>> GetItemCarrinho()
        {
            return await _context.ItemCarrinho.ToListAsync();
        }

        // GET: api/ItemsCarrinho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCarrinho>> GetItemCarrinho(Guid id)
        {
            var itemCarrinho = await _context.ItemCarrinho.FindAsync(id);

            if (itemCarrinho == null)
            {
                return NotFound();
            }

            return itemCarrinho;
        }

        // GET: api/ItemsCarrinho/CalculateValue/5
        [HttpGet("CalculateValue/{id}")]
        public async Task<ActionResult<decimal>> CalculateItemValue(Guid id)
        {
            var itemCarrinho = await _context.ItemCarrinho.FindAsync(id);

            if (itemCarrinho == null)
            {
                return NotFound();
            }

            var valorTotal = itemCarrinho.Quantidade * itemCarrinho.Valor;
            return Ok(valorTotal);
        }

        // GET: api/ItemsCarrinho/CalculateAllValues
        [HttpGet("CalculateAllValues")]
        public async Task<ActionResult<IEnumerable<object>>> CalculateAllItemValues()
        {
            var itemsCarrinho = await _context.ItemCarrinho.ToListAsync();

            var valores = itemsCarrinho.Select(item => new
            {
                ItemCarrinhoId = item.ItemCarrinhoId,
                ValorTotal = item.Quantidade * item.Valor
            }).ToList();

            return Ok(valores);
        }

        // PUT: api/ItemsCarrinho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCarrinho(Guid id, ItemCarrinho itemCarrinho)
        {
            if (id != itemCarrinho.ItemCarrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(itemCarrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCarrinhoExists(id))
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

        // POST: api/ItemsCarrinho
        [HttpPost]
        public async Task<ActionResult<ItemCarrinho>> PostItemCarrinho(ItemCarrinho itemCarrinho)
        {
            _context.ItemCarrinho.Add(itemCarrinho);
            await _context.SaveChangesAsync();

            await UpdateCarrinhoTotal(itemCarrinho.CarrinhoId);

            return CreatedAtAction("GetItemCarrinho", new { id = itemCarrinho.ItemCarrinhoId }, itemCarrinho);
        }

        // DELETE: api/ItemsCarrinho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemCarrinho(Guid id)
        {
            var itemCarrinho = await _context.ItemCarrinho.FindAsync(id);
            if (itemCarrinho == null)
            {
                return NotFound();
            }

            _context.ItemCarrinho.Remove(itemCarrinho);
            await _context.SaveChangesAsync();

            await UpdateCarrinhoTotal(itemCarrinho.CarrinhoId);

            return NoContent();
        }

        private bool ItemCarrinhoExists(Guid id)
        {
            return _context.ItemCarrinho.Any(e => e.ItemCarrinhoId == id);
        }

        private async Task UpdateCarrinhoTotal(Guid carrinhoId)
        {
            var carrinho = await _context.Carrinho.FindAsync(carrinhoId);
            if (carrinho != null)
            {
                carrinho.Total = await _context.ItemCarrinho
                    .Where(i => i.CarrinhoId == carrinhoId)
                    .SumAsync(i => i.Quantidade * i.Valor);

                _context.Entry(carrinho).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
