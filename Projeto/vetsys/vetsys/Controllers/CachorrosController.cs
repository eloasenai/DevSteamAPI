using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CachorroController : ControllerBase
    {
        private static List<Cachorro> cachorros = new List<Cachorro>
        {
            new Cachorro
            {
                Id = 1,
                Racao = "Ração Pedigree",
                Petisco = "Bifinho",
                Brinquedo = "Bola de borracha",
                Preco = 59.90m,
                IngredienteOuSabor = "Carne",
                Descricao = "Ração básica para cães adultos com sabor carne. Brinquedo ideal para mordidas fortes.",
                Tamanho = "2kg",
                Idade = "Adulto"
            },
            new Cachorro
            {
                Id = 2,
                Racao = "Ração Golden",
                Petisco = "Dental Stix",
                Brinquedo = "Corda trançada",
                Preco = 74.50m,
                IngredienteOuSabor = "Frango",
                Descricao = "Ração premium com proteção bucal. Petisco ajuda na limpeza dos dentes.",
                Tamanho = "3kg",
                Idade = "Filhote"
            },
            new Cachorro
            {
                Id = 3,
                Racao = "Ração Premier",
                Petisco = "Petisco Orgânico",
                Brinquedo = "Osso de Nylon",
                Preco = 89.90m,
                IngredienteOuSabor = "Carne Natural",
                Descricao = "Alimento natural para cães exigentes. Brinquedo resistente ao desgaste.",
                Tamanho = "1.5kg",
                Idade = "Adulto"
            },
            new Cachorro
            {
                Id = 4,
                Racao = "Ração Royal Canin",
                Petisco = "Petisco de Carne",
                Brinquedo = "Frisbee",
                Preco = 102.00m,
                IngredienteOuSabor = "Sabor Carne Especial",
                Descricao = "Indicado para cães com sensibilidade digestiva. Frisbee para exercícios ao ar livre.",
                Tamanho = "4kg",
                Idade = "Sênior"
            },
            new Cachorro
            {
                Id = 5,
                Racao = "Ração Pro Plan",
                Petisco = "Petisco de Frango",
                Brinquedo = "Pelúcia",
                Preco = 95.60m,
                IngredienteOuSabor = "Frango e Arroz",
                Descricao = "Nutrição avançada com prebióticos. Brinquedo confortável para cães filhotes.",
                Tamanho = "2.5kg",
                Idade = "Filhote"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Cachorro>> GetTodos()
        {
            return Ok(cachorros);
        }

        [HttpGet("racoes")]
        public ActionResult<IEnumerable<string>> GetRacoes()
        {
            return Ok(cachorros.Select(c => c.Racao).Distinct());
        }

        [HttpGet("petiscos")]
        public ActionResult<IEnumerable<string>> GetPetiscos()
        {
            return Ok(cachorros.Select(c => c.Petisco).Distinct());
        }

        [HttpGet("brinquedos")]
        public ActionResult<IEnumerable<string>> GetBrinquedos()
        {
            return Ok(cachorros.Select(c => c.Brinquedo).Distinct());
        }
    }
}
