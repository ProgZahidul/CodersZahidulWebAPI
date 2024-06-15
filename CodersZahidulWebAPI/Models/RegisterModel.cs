using System.ComponentModel.DataAnnotations;

namespace CodersZahidulWebAPI.Models
{
    public class RegisterModel
    {
        [Required (ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Role { get; set; }
    }
}
