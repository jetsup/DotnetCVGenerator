namespace CVGenerator.Models;
public class CVModel
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    // raw string
    public string ProfessionalSummary { get; set; }
    public string WorkExperience { get; set; }
    public string EducationBackground { get; set; }
    public string Skills { get; set; }
    public string Languages { get; set; }
}
