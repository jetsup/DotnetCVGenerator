using CVGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.Controllers
{
    [Route("cv/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly PdfGeneration _pdfGeneration;

        public PdfController(PdfGeneration pdfGeneration)
        {
            _pdfGeneration = pdfGeneration;
        }

        /*Generates a PDF file from the CV data.
        * Download a PDF file on success
        */
        [HttpGet]
        public IActionResult GeneratePdf()
        {
            Console.WriteLine("GetPDF GET");
            var pdf = _pdfGeneration.GenerateAlphaPdf(/*html*/);
            Console.WriteLine("Download complete");

            var fileName = CvController.cvDataModel.Name + "_CV.pdf";
            return File(pdf.Result, "application/pdf", fileName);
        }
    }
}
