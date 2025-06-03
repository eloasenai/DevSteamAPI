using Microsoft.AspNetCore.Mvc;
using vetsys.Models;
using System.Collections.Generic;
using System.Linq;

namespace vetsys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PesquisarController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Ração para Gatos", Preco = 50 },
            new Produto { Id = 2, Nome = "Petisco para Cães", Preco = 20 },
            new Produto { Id = 3, Nome = "Areia Higiênica", Preco = 30 },
            new Produto { Id = 4, Nome = "Brinquedo para Gatos", Preco = 15 },
            new Produto { Id = 5, Nome = "Coleira para Cães", Preco = 25 },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get([FromQuery] string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return BadRequest("Termo de pesquisa é obrigatório.");

            var resultados = produtos
                .Where(p => p.Nome.ToLower().Contains(termo.ToLower()))
                .ToList();

            return Ok(resultados);
        }
    }
}
