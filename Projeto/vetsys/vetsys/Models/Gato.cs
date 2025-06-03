namespace ProjetoApi.Models
{
    public class Gato
    {
        public int Id { get; set; }
        public string Racao { get; set; }
        public string Petisco { get; set; }
        public string Areia { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string IngredienteOuSabor { get; set; }
        public string Tamanho { get; set; }       // Ex: "1kg", "10 unidades", "4L"
        public string Idade { get; set; }         // Ex: "Filhote", "Adulto", "Sênior"
    }
}
