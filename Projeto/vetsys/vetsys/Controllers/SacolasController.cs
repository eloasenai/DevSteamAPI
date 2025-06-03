using Microsoft.AspNetCore.Mvc;
using vetsys.Models;
using System.Collections.Generic;
using System.Linq;

namespace vetsys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SacolaController : ControllerBase
    {
        private static Sacola sacola = new Sacola { Id = 1 };

        [HttpGet]
        public ActionResult<Sacola> GetSacola()
        {
            return Ok(sacola);
        }

        [HttpPost("adicionar")]
        public ActionResult AdicionarProduto([FromBody] Produto produto)
        {
            var produtoExistente = sacola.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += produto.Quantidade;
            }
            else
            {
                sacola.Produtos.Add(produto);
            }

            return Ok(sacola);
        }

        [HttpDelete("remover/{produtoId}")]
        public ActionResult RemoverProduto(int produtoId)
        {
            var produto = sacola.Produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null) return NotFound("Produto não encontrado na sacola.");

            sacola.Produtos.Remove(produto);
            return Ok(sacola);
        }
    }
}
