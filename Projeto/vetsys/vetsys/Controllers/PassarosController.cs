using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassarosController : ControllerBase
    {
        private static List<Passaros> passaros = new List<Passaros>
        {
            new Passaros
            {
                Id = 1,
                Racao = "Ração Vitakraft",
                Brinquedo = "Espelho Colorido",
                Acessorio = "Poleiro de Madeira",
                Preco = 25.90m,
                IngredienteOuSabor = "Mistura de sementes",
                Descricao = "Ração balanceada para pássaros pequenos. Brinquedo e acessório para diversão e conforto.",
                Tamanho = "500g",
                Idade = "Adulto"
            },
            new Passaros
            {
                Id = 2,
                Racao = "Ração Periquito",
                Brinquedo = "Sino de Metal",
                Acessorio = "Gaiola Pequena",
                Preco = 19.90m,
                IngredienteOuSabor = "Mistura especial para periquitos",
                Descricao = "Alimento específico para periquitos. Brinquedo para estímulo e gaiola confortável.",
                Tamanho = "1kg",
                Idade = "Filhote"
            },
            new Passaros
            {
                Id = 3,
                Racao = "Ração Papagaio",
                Brinquedo = "Corda Colorida",
                Acessorio = "Balanço de Corda",
                Preco = 35.90m,
                IngredienteOuSabor = "Mistura tropical",
                Descricao = "Ração nutritiva para papagaios. Brinquedo e acessório para enriquecimento ambiental.",
                Tamanho = "700g",
                Idade = "Adulto"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Passaros>> GetTodos()
        {
            return Ok(passaros);
        }

        [HttpGet("racoes")]
        public ActionResult<IEnumerable<string>> GetRacoes()
        {
            return Ok(passaros.Select(p => p.Racao).Distinct());
        }

        [HttpGet("brinquedos")]
        public ActionResult<IEnumerable<string>> GetBrinquedos()
        {
            return Ok(passaros.Select(p => p.Brinquedo).Distinct());
        }

        [HttpGet("acessorios")]
        public ActionResult<IEnumerable<string>> GetAcessorios()
        {
            return Ok(passaros.Select(p => p.Acessorio).Distinct());
        }
    }
}
