using System.ComponentModel.DataAnnotations;
using CVGenerator.Utils;

namespace CVGenerator.Models;
public class CVModel
{
    /* 
    This model is used to store the data from the form.
    It is important that the variable name to match the name attribute in the form.
    */
    [Display(Name = "Full Name")]
    [NameValidation]
    public string Name { get; set; } = "";

    [Display(Name = "Phone Number")]
    [PhoneValidation]
    public string Phone { get; set; } = "";

    [Display(Name = "Email Address")]
    [Required]
    public string Email { get; set; } = "";

    [Display(Name = "Address (Town, City, Country)")]
    [AddressValidation]
    public string Address { get; set; } = "";

    // raw string
    [Display(Name = "Professional Summary (each in a new line)")]
    [ProfessionalSummaryValidation]
    public string ProfessionalSummary { get; set; } = "";

    [Display(Name = "Work Experience (CSV each on A new line: title,company,date of employment,expertise)")]
    [WorkExperienceValidation]
    public string WorkExperience { get; set; } = "";

    [Display(Name = "Education Background (CSV each on A new line: institution,certification,graduation date)")]
    [EducationBackgroundValidation]
    public string EducationBackground { get; set; } = "";

    [Display(Name = "Skills (CSV each on A new line: skill,level)")]
    [SkillsValidation]
    public string Skills { get; set; } = "";

    [Display(Name = "Languages (CSV each on A new line: language,proficiency)")]
    [LanguagesValidation]
    public string Languages { get; set; } = "";
}
