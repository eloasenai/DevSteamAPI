namespace vetsys.Models
{
    public class TelaPagamento
    {
        public Guid TelaPagamentoId { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamento { get; set; } // Ex: Cartão, Boleto, Pix
        public string Status { get; set; } // Ex: Pendente, Confirmado, Cancelado
        public DateTime DataPagamento { get; set; }
    }
}
