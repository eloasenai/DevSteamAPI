using System;

namespace Vetsys.Models
{
    public class Oferta
    {
        public Guid OfertaId { get; set; }
        public string Remedio { get; set; }
        public string Coleira { get; set; }
        public string Petisco { get; set; }
        public decimal Preco { get; set; }
        public double Desconto { get; set; }
        public DateTime ValidoAte { get; set; }
    }
}
