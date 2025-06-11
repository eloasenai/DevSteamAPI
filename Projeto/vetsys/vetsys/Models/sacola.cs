namespace vetsys.Models
{

    public class Sacola
    {
        public Guid SacolaId { get; set; }
        public List<Produtos> Produtos { get; set; } = new List<Produtos>();
    }
}
