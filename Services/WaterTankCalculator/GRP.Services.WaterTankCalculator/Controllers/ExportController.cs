using IronPdf;

using System.Drawing;

namespace GRP.Services.WaterTankCalculator.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ExportController : ControllerBase
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public ExportController(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;
    }
    static void LoadImage(string root, string name, ref string htmlcontent)
    {
        var image = Path.Combine(root, "Template", name);
        string uri = IronPdf.Imaging.ImageUtilities.ImageToDataUri(Image.FromFile(image));
        htmlcontent.Replace(name, uri);
    }
    [HttpGet]
    public IActionResult Get()
    {
        var templatePath = Path.Combine(webHostEnvironment.WebRootPath, "Template", "withbootstrap.html");
        var htmlContent = System.IO.File.ReadAllText(templatePath);
        //LoadImage(webHostEnvironment.WebRootPath, "ce.png", ref htmlContent);
        //LoadImage(webHostEnvironment.WebRootPath, "Iso.png", ref htmlContent);
        //LoadImage(webHostEnvironment.WebRootPath, "logo.png", ref htmlContent);
        //LoadImage(webHostEnvironment.WebRootPath, "tse.png", ref htmlContent);
        //LoadImage(webHostEnvironment.WebRootPath, "wras.png", ref htmlContent);

        var Renderer = new IronPdf.ChromePdfRenderer();
        Renderer.RenderingOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;
        var PDF = Renderer.RenderHtmlAsPdf(htmlContent);
        var path = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{Guid.NewGuid()}.pdf");
        PDF.SaveAs(path);

        var stream = System.IO.File.OpenRead(path);
        var contentType = "application/pdf";
        return File(stream, contentType, "Exports.pdf");
    }
}
