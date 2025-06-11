using System.ComponentModel.DataAnnotations;

namespace vetsys.Models
{
    public class Login
    {
        public Guid LoginId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
