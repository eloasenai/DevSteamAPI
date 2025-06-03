namespace ProjetoApi.Models
{
    public class Cachorro
    {
        public int Id { get; set; }
        public string Racao { get; set; }
        public string Petisco { get; set; }
        public string Brinquedo { get; set; }
        public decimal Preco { get; set; }
        public string IngredienteOuSabor { get; set; }
        public string Descricao { get; set; }
        public string Tamanho { get; set; }  // Ex: "1kg", "500g"
        public string Idade { get; set; }    // Ex: "Filhote", "Adulto", "Sênior"
    }
}
