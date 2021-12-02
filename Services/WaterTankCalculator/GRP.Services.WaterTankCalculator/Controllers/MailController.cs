namespace GRP.Services.WaterTankCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailController : ControllerBase
{
    private readonly IMailService mailService;

    public MailController(IMailService mailService)
    {
        this.mailService = mailService;
    }
    [HttpPost("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response= await mailService.SendAsync(id);
        return response.CreateResponseInstance();
    }
}
