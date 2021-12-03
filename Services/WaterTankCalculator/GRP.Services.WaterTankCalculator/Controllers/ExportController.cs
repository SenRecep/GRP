


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
        var path = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{id}.pdf");
        var content = System.IO.File.OpenRead(path);
        return File(content, "application/pdf", "Exports.pdf");
    }
}
