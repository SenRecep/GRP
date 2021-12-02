

using SelectPdf;

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

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    { 
        var path = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{id}.html");
        var content = System.IO.File.ReadAllText(path);
        HtmlToPdf converter = new();
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
        PdfDocument doc = converter.ConvertHtmlString(content);
        var ms= new MemoryStream();
        doc.Save(ms);
        doc.Close();
        ms.Position = 0;
        return File(ms, "application/pdf", "Exports.pdf");
    }
}
