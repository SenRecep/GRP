
namespace GRP.Services.WaterTankCalculator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeamPlinthController : ControllerBase
{
    [HttpPost]
    public IActionResult Calculate()
    {
        return Response<string>
            .Success(StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
