namespace vetsys.Models
{
    public class Produtos
    {
        public Guid ProdutosId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
