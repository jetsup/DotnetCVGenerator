using CVGenerator.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Razor.Templating.Core;

namespace CVGenerator.Services
{
    public class PdfGeneration
    {
        private IConverter _converter;
        public PdfGeneration(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> GenerateAlphaPdf(/*string html*/)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = "CV"
            };

            var cvDataModel = new CVModel
            {
                Name = "John Doe",
                Phone = "1234567890",
                Email = "doe@mail.com",
                Address = "123, Doe Street, Doe City, Doe Country",
                ProfessionalSummary = "Network Engineer with 5 years of experience in network design and implementation\nSoftware Developer with 3 years of experience in web development",
                WorkExperience = "Software Developer,Safaricom,2020-2021\nWeb Developer,Google,2019-2020\nIntern,Microsoft,2018-2019",
                EducationBackground = "Bachelor of Science in Computer Science,University of Nairobi,2018\nDiploma in Information Technology,JKUAT,2015\nCertificate in Web Development,Strathmore University,2014",
                Skills = "Coding,Intermediate\nDesign,Advanced\nWriting,Beginner",
                Languages = "English,Beginner\nFrench,Intermediate\nSpanish,Advanced"
            };
            var html = await RazorTemplateEngine.RenderPartialAsync("Views/CV/Preview.cshtml", cvDataModel, null);

            var objectSettings = new ObjectSettings
            {
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" },
            };

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var pdfBytes = new byte[3];

            try
            {
                Console.WriteLine("PDF Generated: " + html + ":>>>" + _converter.ToString() + "<<<:");

                pdfBytes = _converter.Convert(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PDF Generation failed: " + ex.Message);
                throw;
            }

            Console.Write("PDF Bytes: ");
            Console.WriteLine(pdfBytes.ToString() + "<<<<");

            // return File(pdfBytes, "application/pdf", "CV.pdf");
            return pdfBytes;
        }
    }
}
