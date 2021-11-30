using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using GRP.Services.WaterTankCalculator.Entities.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GRP.Services.WaterTankCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly WaterTankCalculatorDbContext context;
        private readonly ICompanyService companyService;

        public HistoryController(
            WaterTankCalculatorDbContext context,
                ICompanyService companyService)
        {
            this.context = context;
            this.companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var histories = await context.CalculationHistories.ToListAsync();
            var companies = await companyService.GetCompanies();
            var response = histories.Select(history =>
            {
                var company = companies.FirstOrDefault(x => x.Id == history.CompnyId);
                return new CalculateHistoryWithDateResponse()
                {
                    Time=history.CreatedTime,
                    Company = company?.Title,
                    PaymentType = history.PaymentType,
                    FullTotal = history.FullTotal,
                    KDV = history.KDV,
                    Total = history.Total
                };
            });
            return Response<IEnumerable<CalculateHistoryWithDateResponse>>.Success(response).CreateResponseInstance();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var history = await context.CalculationHistories
               .Include(x => x.CalculateModelHistories)
               .ThenInclude(x => x.TotalCostHistory)
               .Include(x => x.CalculateModelHistories)
               .ThenInclude(x => x.EdgeModelHistory)
               .FirstOrDefaultAsync(x => x.Id == id);
            var company = await companyService.GetByIdAsync(history.CompnyId.Value);
            var tanks = history.CalculateModelHistories.Select(x =>
            {
                var type = x.PlinthType == PlinthType.Flat ? "Düz Kaide" : "Kriş Kaide";
                return new Tank()
                {
                    Type = type,
                    Capacity = x.EdgeModelHistory.Capacity,
                    Width = x.Width,
                    Length = x.Length,
                    Height = x.Height,
                    Quantity = x.Quantity,
                    Total = x.TotalCostHistory.Total,
                    FullTotal = x.TotalCostHistory.FullTotal
                };
            });
            return Response<CalculateHistoryResponse>.Success(new CalculateHistoryResponse()
            {
                Company = company.Title,
                Tanks = tanks,
                PaymentType = history.PaymentType,
                FullTotal = history.FullTotal,
                KDV = history.KDV,
                Total = history.Total
            }).CreateResponseInstance();
        }

    }
}
