using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Utils
{

    public class NameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name is required");
                return new ValidationResult("Name is required");
            }
            else if (name.Trim().Split(" ").Length < 2 || name.Trim().Split(" ").Length > 3)
            {
                Console.WriteLine("Name is not formatted correctly. Should be FirstName [MiddleName] LastName");
                return new ValidationResult("Name is not formatted correctly. Should be FirstName [MiddleName] LastName");
            }

            return ValidationResult.Success;
        }
    }

    public class PhoneValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var phone = value as string;

            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Phone is required");
                return new ValidationResult("Phone is required");
            }
            else if (phone.Length < 10 || phone.Length > 14)
            {
                Console.WriteLine("Phone number should be 10 digits");
                return new ValidationResult("Phone number should be 10 to 14 digits");
            }

            return ValidationResult.Success;
        }
    }

    public class AddressValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var address = value as string;

            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Address is required");
                return new ValidationResult("Address is required");
            }
            else if (address.Trim().Trim(',').Split(",").Length != 3)
            {
                Console.WriteLine("Address is not formatted correctly. Should be Town, City, Country");
                return new ValidationResult("Address is not formatted correctly. Should be Town, City, Country");
            }

            return ValidationResult.Success;
        }
    }

    public class ProfessionalSummaryValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var professionalSummary = value as string;

            if (string.IsNullOrEmpty(professionalSummary))
            {
                Console.WriteLine("Professional Summary is required");
                return new ValidationResult("Professional Summary is required");
            }

            return ValidationResult.Success;
        }
    }

    public class WorkExperienceValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var workExperience = value as string;

            if (string.IsNullOrEmpty(workExperience))
            {
                Console.WriteLine("Work Experience is required");
                return new ValidationResult("Work Experience is required");
            }
            else
            {
                var experiences = workExperience.Trim('\n').Split("\n");
                foreach (var experience in experiences)
                {
                    if (experience.Trim().Trim(',').Split(",").Length != 4)
                    {
                        Console.WriteLine("Work Experience is not formatted correctly. Should be title, company, date of employment, expertise");
                        return new ValidationResult("Work Experience is not formatted correctly. Should be title, company, date of employment, expertise");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }

    public class EducationBackgroundValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var educationBackground = value as string;

            if (string.IsNullOrEmpty(educationBackground))
            {
                Console.WriteLine("Education Background is required");
                return new ValidationResult("Education Background is required");
            }
            else
            {
                var educations = educationBackground.Trim('\n').Split("\n");
                foreach (var education in educations)
                {
                    if (education.Trim().Trim(',').Split(",").Length != 3)
                    {
                        Console.WriteLine("Education Background is not formatted correctly. Should be institution, certification, graduation date");
                        return new ValidationResult("Education Background is not formatted correctly. Should be institution, certification, graduation date");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }

    public class SkillsValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var skills = value as string;

            if (string.IsNullOrEmpty(skills))
            {
                Console.WriteLine("Skills is required");
                return new ValidationResult("Skills is required");
            }
            else
            {
                var skillList = skills.Trim('\n').Split("\n");
                foreach (var skill in skillList)
                {
                    if (skill.Trim().Trim(',').Split(",").Length != 2)
                    {
                        Console.WriteLine("Skills is not formatted correctly. Should be skill, level");
                        return new ValidationResult("Skills is not formatted correctly. Should be skill, level");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }

    public class LanguagesValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var languages = value as string;

            if (string.IsNullOrEmpty(languages))
            {
                Console.WriteLine("Languages is required");
                return new ValidationResult("Languages is required");
            }
            else
            {
                var languageList = languages.Trim('\n').Split("\n");
                foreach (var language in languageList)
                {
                    if (language.Trim().Trim(',').Split(",").Length != 2)
                    {
                        Console.WriteLine("Languages is not formatted correctly. Should be language, proficiency");
                        return new ValidationResult("Languages is not formatted correctly. Should be language, proficiency");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
