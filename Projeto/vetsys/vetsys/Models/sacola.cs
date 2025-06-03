namespace vetsys.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class Sacola
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
