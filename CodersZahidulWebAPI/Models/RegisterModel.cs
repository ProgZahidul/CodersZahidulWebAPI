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
    }
}
