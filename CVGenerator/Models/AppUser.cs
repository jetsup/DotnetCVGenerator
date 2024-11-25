using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CVGenerator.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string ProfessionalSummary { get; set; } = "";
        public string WorkExperience { get; set; } = "";
        public string Education { get; set; } = "";
        public string Languages { get; set; } = "";
        public string Skills { get; set; } = "";
    }
}
