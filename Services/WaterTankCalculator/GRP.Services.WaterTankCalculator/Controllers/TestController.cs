using GRP.Core.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRP.Services.WaterTankCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Response<EntityBase>.Success(new()
        {
            CreatedTime = DateTime.Now,
            CreatedUserId = Guid.NewGuid(),
            Id = Guid.NewGuid(),
            IsDeleted = false,
            UpdatedTime = DateTime.Now,
            UpdatedUserId = Guid.NewGuid(),
        },StatusCodes.Status200OK).CreateResponseInstance();
    }
}
