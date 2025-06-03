using Microsoft.AspNetCore.Mvc;
using Vetsys.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vetsys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : ControllerBase
    {
        private static List<Oferta> ofertas = new List<Oferta>
        {
            new Oferta
            {
                Id = 1,
                Remedio = "Vermífugo Drontal",
                Coleira = "Coleira antipulgas Seresto",
                Petisco = "Snack Dental",
                Preco = 89.90m,
                Desconto = 10,
                ValidoAte = new DateTime(2025, 7, 15)
            },
            new Oferta
            {
                Id = 2,
                Remedio = "Antipulgas Bravecto",
                Coleira = "Coleira com GPS",
                Petisco = "Bifinho Orgânico",
                Preco = 149.99m,
                Desconto = 15,
                ValidoAte = new DateTime(2025, 8, 1)
            },
            new Oferta
            {
                Id = 3,
                Remedio = "Suplemento Ômega 3",
                Coleira = "Coleira reflexiva",
                Petisco = "Petisco Natural Veggie",
                Preco = 59.50m,
                Desconto = 5,
                ValidoAte = new DateTime(2025, 6, 30)
            },
            new Oferta
            {
                Id = 4,
                Remedio = "Antibiótico Amoxicilina",
                Coleira = "Coleira repelente de mosquitos",
                Petisco = "Petisco de Frango",
                Preco = 45.00m,
                Desconto = 20,
                ValidoAte = new DateTime(2025, 9, 10)
            },
            new Oferta
            {
                Id = 5,
                Remedio = "Antiinflamatório Meloxicam",
                Coleira = "Coleira de identificação",
                Petisco = "Petisco de Carne",
                Preco = 75.00m,
                Desconto = 12,
                ValidoAte = new DateTime(2025, 10, 5)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Oferta>> GetTodos()
        {
            return Ok(ofertas);
        }

        [HttpGet("ativas")]
        public ActionResult<IEnumerable<Oferta>> GetAtivas()
        {
            var hoje = DateTime.Today;
            return Ok(ofertas.Where(o => o.ValidoAte >= hoje));
        }

        [HttpGet("descontos")]
        public ActionResult<IEnumerable<object>> GetDescontos()
        {
            return Ok(ofertas.Select(o => new
            {
                o.Remedio,
                o.Coleira,
                o.Petisco,
                o.Preco,
                o.Desconto,
                o.ValidoAte
            }));
        }
    }
}
