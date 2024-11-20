using CVGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.Controllers
{
    [Route("cv/[controller]")]
    // for http get request to download the cv
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly PdfGeneration _pdfGeneration;

        public PdfController(PdfGeneration pdfGeneration)
        {
            _pdfGeneration = pdfGeneration;
        }

        [HttpGet]
        public IActionResult GeneratePdf(/*string html*/)
        {
            Console.WriteLine("GetPDF GET");
            var pdf = _pdfGeneration.GenerateAlphaPdf(/*html*/);
            Console.WriteLine("Download complete");
            return File(pdf.Result, "application/pdf", "CV.pdf");
        }
    }
}
