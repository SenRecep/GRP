using GRP.Shared.Core.Response;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IMailService
{
    Task<Response<string>> SendAsync(Guid id);
}
