using CVGenerator.Controllers;
using DinkToPdf;
using DinkToPdf.Contracts;
using Razor.Templating.Core;

namespace CVGenerator.Services
{
    /*
    * This class is used to generate a PDF file from the CV data.
    * It uses the DinkToPdf library to convert the HTML to a PDF file.
    * The HTML is generated using the Razor.Templating.Core library.
    * The GenerateAlphaPdf method generates the PDF file.
    */
    public class PdfGeneration
    {
        private IConverter _converter;
        public PdfGeneration(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> GenerateAlphaPdf(int previewID = 1)
        {
            // Set the global settings for the PDF
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = "CV"
            };

            // Get the CV data model. This is the data that was entered in the form.
            var cvDataModel = CvController.cvDataModel;

            // Check if the preview ID is valid. If it is, set the preview name.
            var previewName = "Preview";
            if (previewID > 1 && previewID <= CvController.NUMBER_OF_PREVIEW_PAGES)
            {
                previewName = "Preview" + previewID;
            }

            // Render the HTML using the Razor template engine
            var html = await RazorTemplateEngine.RenderPartialAsync("Views/CV/" + previewName + ".cshtml", cvDataModel, null);

            // Set the object settings for the PDF. This includes the HTML content and the web settings.
            var objectSettings = new ObjectSettings
            {
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" },
            };

            // Create the PDF document.
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _ = new byte[3];
            byte[]? pdfBytes;
            try
            {
                pdfBytes = _converter.Convert(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PDF Generation failed: " + ex.Message);
                throw;
            }
            return pdfBytes;
        }
    }
}
