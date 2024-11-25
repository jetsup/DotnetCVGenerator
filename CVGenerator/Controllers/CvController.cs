using Microsoft.AspNetCore.Mvc;
using CVGenerator.Models;
using Microsoft.AspNetCore.Identity;

namespace CVGenerator.Controllers;

public class CvController : Controller
{
    // accessible through out the program FIXME: not ideal for use if system has multiple users
    public static CVModel cvDataModel = new();
    private readonly ILogger<CvController> _logger;
    public static readonly int NUMBER_OF_PREVIEW_PAGES = 3;

    private readonly UserManager<AppUser> _userManager;

    public CvController(ILogger<CvController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // if user is logged in, initialize the cvDataModel with the user's from AppUser model data if not yet initialized
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User); // Get the logged-in user
            cvDataModel.Name = user.Name;
            cvDataModel.Email = user.Email;
            cvDataModel.Phone = user.PhoneNumber;
            cvDataModel.Address = user.Address;
            cvDataModel.ProfessionalSummary = user.ProfessionalSummary;
            cvDataModel.WorkExperience = user.WorkExperience;
            cvDataModel.EducationBackground = user.Education;
            cvDataModel.Languages = user.Languages;
            cvDataModel.Skills = user.Skills;

            return View(cvDataModel);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CVModel cvModel)
    {
        if (ModelState.IsValid)
        {
            // update the logged in user info with this new data
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                user.Name = cvModel.Name;
                user.Email = cvModel.Email;
                user.PhoneNumber = cvModel.Phone;
                user.Address = cvModel.Address;
                user.ProfessionalSummary = cvModel.ProfessionalSummary;
                user.WorkExperience = cvModel.WorkExperience;
                user.Education = cvModel.EducationBackground;
                user.Languages = cvModel.Languages;
                user.Skills = cvModel.Skills;

                await _userManager.UpdateAsync(user);
            }

            cvDataModel = cvModel;
            
            return RedirectToAction("Preview", new { id = 1 });
        }
        else
        {
            return View(cvModel);
        }
    }

    // change the Preview to links: http://localhost:5000/Cv/Preview/previewID
    [HttpGet("/Cv/Preview/{id:int}")]
    public IActionResult Preview(int id)
    {
        var previewName = "Preview";
        if (id > 1 && id <= NUMBER_OF_PREVIEW_PAGES)
        {
            previewName += id;
        }

        return PartialView(previewName, cvDataModel);
    }
}
