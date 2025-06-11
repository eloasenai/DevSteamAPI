namespace vetsys.Models
{
    public class Itens
    {
        public Guid ItensId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
