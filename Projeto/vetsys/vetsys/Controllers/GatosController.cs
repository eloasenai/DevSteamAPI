using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatoController : ControllerBase
    {
        private static List<Gato> gatos = new List<Gato>
        {
            new Gato
            {
                Id = 1,
                Racao = "Ração Whiskas",
                Petisco = "Petisco Dreamies",
                Areia = "Areia Pipicat",
                Preco = 45.90m,
                IngredienteOuSabor = "Sabor Carne",
                Descricao = "Ração seca balanceada para gatos adultos. Rica em fibras e proteínas.",
                Tamanho = "1kg",
                Idade = "Adulto"
            },
            new Gato
            {
                Id = 2,
                Racao = "Ração Golden",
                Petisco = "Petisco Whiskas",
                Areia = "Areia Granulado de Madeira",
                Preco = 52.50m,
                IngredienteOuSabor = "Sabor Frango",
                Descricao = "Ração premium com ingredientes naturais. Ideal para gatos exigentes.",
                Tamanho = "3kg",
                Idade = "Filhote"
            },
            new Gato
            {
                Id = 3,
                Racao = "Ração Premier",
                Petisco = "Petisco Fancy Feast",
                Areia = "Areia Sílica Azul",
                Preco = 67.80m,
                IngredienteOuSabor = "Sabor Peixe",
                Descricao = "Alimento completo com ômegas e antioxidantes. Alta digestibilidade.",
                Tamanho = "2kg",
                Idade = "Sênior"
            },
            new Gato
            {
                Id = 4,
                Racao = "Ração Royal Canin",
                Petisco = "Petisco Pedigree",
                Areia = "Areia Natural",
                Preco = 89.99m,
                IngredienteOuSabor = "Sabor Salmão",
                Descricao = "Fórmula veterinária para gatos sensíveis. Indicado para digestão delicada.",
                Tamanho = "1.5kg",
                Idade = "Adulto"
            },
            new Gato
            {
                Id = 5,
                Racao = "Ração Pro Plan",
                Petisco = "Petisco Hill's",
                Areia = "Areia de Argila",
                Preco = 78.30m,
                IngredienteOuSabor = "Sabor Frango e Arroz",
                Descricao = "Nutrição avançada com prebióticos. Indicado para todas as idades.",
                Tamanho = "4kg",
                Idade = "Todas as idades"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Gato>> GetTodos()
        {
            return Ok(gatos);
        }

        [HttpGet("racoes")]
        public ActionResult<IEnumerable<string>> GetRacoes()
        {
            return Ok(gatos.Select(g => g.Racao).Distinct());
        }

        [HttpGet("petiscos")]
        public ActionResult<IEnumerable<string>> GetPetiscos()
        {
            return Ok(gatos.Select(g => g.Petisco).Distinct());
        }

        [HttpGet("areias")]
        public ActionResult<IEnumerable<string>> GetAreias()
        {
            return Ok(gatos.Select(g => g.Areia).Distinct());
        }
    }
}
