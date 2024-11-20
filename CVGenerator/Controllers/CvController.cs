using Microsoft.AspNetCore.Mvc;
using CVGenerator.Models;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using RazorEngineCore;
using Razor.Templating.Core;
using CVGenerator.Services;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace CVGenerator.Controllers;

public class CvController : Controller
{
    private CVModel cvDataModel = new();
    private readonly ILogger<CvController> _logger;

    public CvController(ILogger<CvController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // public PdfDocument GetCV(){
    //     var document = new Document();
    //     var pdfRenderer = new PdfDocumentRenderer();

    //     pdfRenderer.RenderDocument();

    //     return pdfRenderer.PdfDocument;
    // }


    // public async Task<IActionResult> LoadPreviewHtml([FromServices] PdfGeneration pdfGeneration)
    // {
    //     // var html = await RazorTemplateEngine.RenderAsync("Views/CV/Preview.cshtml", cvDataModel);

    //     // Console.WriteLine(html);
    //     // return html;

    //     var html = await RazorTemplateEngine.RenderAsync("Views/CV/Preview.cshtml", cvDataModel);
    //     Console.WriteLine(html);

    //     var pdfBytes = pdfGeneration.GenerateAlphaPdf(/*html*/);

    //     Console.WriteLine("Bytes: " + pdfBytes.ToString());

    //     return File(pdfBytes.Result, "application/pdf", "CVMod.pdf");
    // }

    public IActionResult Preview()
    {
        // cvDataModel = new CVModel();
        cvDataModel.Name = "John Doe";
        cvDataModel.Phone = "1234567890";
        cvDataModel.Email = "doe@mail.com";
        cvDataModel.Address = "123, Doe Street, Doe City, Doe Country";
        cvDataModel.ProfessionalSummary = "Network Engineer with 5 years of experience in network design and implementation\nSoftware Developer with 3 years of experience in web development";
        cvDataModel.WorkExperience = "Software Developer,Safaricom,2020-2021\nWeb Developer,Google,2019-2020\nIntern,Microsoft,2018-2019";
        cvDataModel.EducationBackground = "Bachelor of Science in Computer Science,University of Nairobi,2018\nDiploma in Information Technology,JKUAT,2015\nCertificate in Web Development,Strathmore University,2014";
        cvDataModel.Skills = "Coding,Intermediate\nDesign,Advanced\nWriting,Beginner";
        cvDataModel.Languages = "English,Beginner\nFrench,Intermediate\nSpanish,Advanced";

        return PartialView("Preview", cvDataModel); // remove the layout
        // return View("Preview", cvDataModel); // remove the layout
    }


    // download the pdf file created from a .cshtml file
    [HttpPost]
    public ActionResult GeneratePDF(CVModel cvModel)
    {
        if (ModelState.IsValid)
        {
            cvDataModel = cvModel;
            // console log the data
            Console.WriteLine("Name:" + cvModel.Name);
            Console.WriteLine("Phone:" + cvModel.Phone);
            Console.WriteLine("Email:" + cvModel.Email);
            Console.WriteLine("Address:" + cvModel.Address);
            Console.WriteLine("ProfessionalSummary:" + cvModel.ProfessionalSummary);
            Console.WriteLine("WorkExperience:" + cvModel.WorkExperience);
            Console.WriteLine("EducationBackground:" + cvModel.EducationBackground);
            Console.WriteLine("Skills:" + cvModel.Skills);
            Console.WriteLine("Languages:" + cvModel.Languages);

            // get the url from where the data was submitted
            string url = Request.Headers["Referer"].ToString();
            Console.WriteLine("URL:" + url);

            // pass this data to a .cshtml file and generate a pdf
            var Renderer = new ChromePdfRenderer();
            Console.WriteLine("Renderer created");
            // the file is Preview.cshtml
            var PDF = Renderer.RenderHtmlFileAsPdf("CV/Preview.cshtml");
            Console.WriteLine("PDF created");
            // save the file
            PDF.SaveAs("CV.pdf");
            Console.WriteLine("PDF saved");

            // redirect to the url
            return RedirectToAction("Index");
        }
        else
        {
            // console log the error
            Console.WriteLine("Error:" + ModelState.Values);
            return View("Index");
        }
    }
}
