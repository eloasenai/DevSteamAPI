using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoedoresController : ControllerBase
    {
        private static List<Roedores> roedores = new List<Roedores>
        {
            new Roedores
            {
                Id = 1,
                Racao = "Ração Supreme",
                Petisco = "Petisco de Cenoura",
                Acessorio = "Túnel de Brinquedo",
                Preco = 39.90m,
                IngredienteOuSabor = "Sabor Cenoura Natural",
                Descricao = "Ração nutritiva para roedores, rica em fibras.",
                Tamanho = "500g",
                Idade = "Adulto"
            },
            new Roedores
            {
                Id = 2,
                Racao = "Ração Special Care",
                Petisco = "Petisco de Maçã",
                Acessorio = "Bola de Exercício",
                Preco = 29.90m,
                IngredienteOuSabor = "Sabor Maçã",
                Descricao = "Ração para roedores com necessidades especiais.",
                Tamanho = "300g",
                Idade = "Filhote"
            },
            new Roedores
            {
                Id = 3,
                Racao = "Ração Natural",
                Petisco = "Petisco de Alfafa",
                Acessorio = "Casa de Madeira",
                Preco = 49.90m,
                IngredienteOuSabor = "Sabor Alfafa",
                Descricao = "Alimento natural e equilibrado para roedores.",
                Tamanho = "1kg",
                Idade = "Adulto"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Roedores>> GetTodos()
        {
            return Ok(roedores);
        }

        [HttpGet("racoes")]
        public ActionResult<IEnumerable<string>> GetRacoes()
        {
            return Ok(roedores.Select(r => r.Racao).Distinct());
        }

        [HttpGet("petiscos")]
        public ActionResult<IEnumerable<string>> GetPetiscos()
        {
            return Ok(roedores.Select(r => r.Petisco).Distinct());
        }

        [HttpGet("acessorios")]
        public ActionResult<IEnumerable<string>> GetAcessorios()
        {
            return Ok(roedores.Select(r => r.Acessorio).Distinct());
        }
    }
}
