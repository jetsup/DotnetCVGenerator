using System.ComponentModel.DataAnnotations;

namespace CVGenerator.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required in the format 'First [Surname] Last'")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = "";

        [Required(ErrorMessage = "Address is required in the format 'Town, City, Country'")]    
        public string Address { get; set; } = "";
    }
}
