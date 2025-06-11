namespace vetsys.Models
{
    public class Automatico
    {
        public Guid AutomaticoId { get; set; }
        public string Nome { get; set; }
        public string Animal { get; set; } // Ex: "gato", "cachorro", "ave", "roedor"
        public string Categoria { get; set; } // Ex: "ração", "petisco"
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
