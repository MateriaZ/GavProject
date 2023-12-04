using System.ComponentModel.DataAnnotations;

namespace GavResortsTest.Models
{
    public class LoginModel
    {
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Senha { get; set; } 
    }
}
