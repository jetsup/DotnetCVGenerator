using Microsoft.AspNetCore.Mvc;
using CVGenerator.Models;

namespace CVGenerator.Controllers;

public class CvController : Controller
{
    // accessible through out the program FIXME: not ideal for use if system has multiple users
    public static CVModel cvDataModel = new();
    private readonly ILogger<CvController> _logger;
    public static readonly int NUMBER_OF_PREVIEW_PAGES = 3;

    public CvController(ILogger<CvController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // change the Preview to links: http://localhost:5000/Cv/Preview
    [HttpPost("/Cv/Preview")]
    public IActionResult Preview(CVModel cvModel)
    {
        // Check if the model is valid. If it is, assign the model to the cvDataModel.
        if (ModelState.IsValid)
        {
            cvDataModel = cvModel;

            // Trims and removes extra newlines from text fields.
            cvModel.ProfessionalSummary = cvModel.ProfessionalSummary.Trim().Trim('\n');
            cvModel.WorkExperience = cvModel.WorkExperience.Trim().Trim('\n');
            cvModel.EducationBackground = cvModel.EducationBackground.Trim().Trim('\n');
            cvModel.Skills = cvModel.Skills.Trim().Trim('\n');
            cvModel.Languages = cvModel.Languages.Trim().Trim('\n');

            _logger.LogInformation("Professional:>" + cvModel.ProfessionalSummary + "<\n");
            _logger.LogInformation("Experience:>" + cvModel.WorkExperience + "<\n");
            _logger.LogInformation("Education:>" + cvModel.EducationBackground + "<\n");
            _logger.LogInformation("Skills:>" + cvModel.Skills + "<\n");
            _logger.LogInformation("Languages:>" + cvModel.Languages + "<\n");

            return PartialView("Preview", cvDataModel); // remove the layout

            // return View("Preview", cvDataModel); // has the layout
        }
        else
        {
            _logger.LogError("Error:" + ModelState.Values);
            return RedirectToAction("Index");
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
