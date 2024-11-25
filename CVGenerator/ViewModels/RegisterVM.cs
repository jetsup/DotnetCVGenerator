using System.ComponentModel.DataAnnotations;
using CVGenerator.Utils;

namespace CVGenerator.ViewModels
{
    public class RegisterVM
    {
        [NameValidation]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = "";

        [AddressValidation]
        public string Address { get; set; } = "";
    }
}
