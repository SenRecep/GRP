
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

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    { 
        var path = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{id}.html");
        var stream = System.IO.File.OpenRead(path);
        return File(stream, "text/html", "Exports.html");
    }
}
