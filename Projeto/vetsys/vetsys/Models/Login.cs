using System.ComponentModel.DataAnnotations;

namespace vetsys.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
