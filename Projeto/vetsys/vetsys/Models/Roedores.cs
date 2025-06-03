namespace ProjetoApi.Models
{
    public class Roedores
    {
        public int Id { get; set; }
        public string Racao { get; set; }
        public string Petisco { get; set; }
        public string Acessorio { get; set; }
        public decimal Preco { get; set; }
        public string IngredienteOuSabor { get; set; }
        public string Descricao { get; set; }
        public string Tamanho { get; set; }  // Ex: "500g", "10 unidades"
        public string Idade { get; set; }    // Ex: "Filhote", "Adulto"
    }
}
