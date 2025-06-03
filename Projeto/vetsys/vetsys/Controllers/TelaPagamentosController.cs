using Microsoft.AspNetCore.Mvc;
using vetsys.Models;
using System.Collections.Generic;
using System.Linq;

namespace vetsys.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelaPagamentoController : ControllerBase
    {
        private static List<TelaPagamento> pagamentos = new List<TelaPagamento>();

        [HttpGet]
        public ActionResult<IEnumerable<TelaPagamento>> GetPagamentos()
        {
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public ActionResult<TelaPagamento> GetPagamento(int id)
        {
            var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null) return NotFound();
            return Ok(pagamento);
        }

        [HttpPost]
        public ActionResult<TelaPagamento> CriarPagamento([FromBody] TelaPagamento novoPagamento)
        {
            novoPagamento.Id = pagamentos.Count + 1;
            novoPagamento.Status = "Pendente";
            novoPagamento.DataPagamento = DateTime.Now;

            pagamentos.Add(novoPagamento);
            return CreatedAtAction(nameof(GetPagamento), new { id = novoPagamento.Id }, novoPagamento);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPagamento(int id, [FromBody] TelaPagamento pagamentoAtualizado)
        {
            var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null) return NotFound();

            pagamento.Valor = pagamentoAtualizado.Valor;
            pagamento.MetodoPagamento = pagamentoAtualizado.MetodoPagamento;
            pagamento.Status = pagamentoAtualizado.Status;
            pagamento.DataPagamento = pagamentoAtualizado.DataPagamento;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPagamento(int id)
        {
            var pagamento = pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null) return NotFound();

            pagamentos.Remove(pagamento);
            return NoContent();
        }
    }
}
