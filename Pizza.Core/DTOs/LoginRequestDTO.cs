using Pizza.API.Validators;
using System.ComponentModel.DataAnnotations;

namespace Pizza.API.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string? Email { get; set; }
        
        [Required]
        [PasswordValidator]
        public string? Password { get; set; }
    }
}
