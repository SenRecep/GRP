#nullable disable
using AutoMapper;

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
        private readonly IMapper mapper;
        private readonly ICompanyService companyService;

        public HistoryController(
            WaterTankCalculatorDbContext context,
            IMapper mapper,
                ICompanyService companyService)
        {
            this.context = context;
            this.mapper = mapper;
            this.companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var histories = await context.CalculationHistories.Include(x=>x.ConstantsHistory).ToListAsync();
            var companies = await companyService.GetCompanies();
            var response = histories.Select(history =>
            {
                var company = companies.FirstOrDefault(x => x.Id == history.CompnyId);
                if (history.CurrencyType == CurrencyType.TL)
                {
                    history.Total *= history.ConstantsHistory.Dollar;
                    history.FullTotal *= history.ConstantsHistory.Dollar;
                    history.KDV *= history.ConstantsHistory.Dollar;
                }
                return new CalculateHistoryWithDateResponse()
                {
                    Id=history.Id,
                    Time=history.CreatedTime,
                    Company = company?.Title,
                    FullTotal = history.FullTotal,
                    KDV = history.KDV,
                    Total = history.Total,
                    Constants= mapper.Map<ConstantsModel>(history.ConstantsHistory)
                };
            });
            return Response<IEnumerable<CalculateHistoryWithDateResponse>>.Success(response).CreateResponseInstance();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var history = await context.CalculationHistories
                .Include(x => x.ConstantsHistory)
               .Include(x => x.CalculateModelHistories)
               .ThenInclude(x => x.TotalCostHistory)
               .Include(x => x.CalculateModelHistories)
               .ThenInclude(x => x.EdgeModelHistory)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (history.CurrencyType == CurrencyType.TL)
            {
                history.Total *= history.ConstantsHistory.Dollar;
                history.FullTotal *= history.ConstantsHistory.Dollar;
                history.KDV *= history.ConstantsHistory.Dollar;
            }
            var company = await companyService.GetByIdAsync(history.CompnyId.Value);
            var tanks = history.CalculateModelHistories.Select(x =>
            {
                if (history.CurrencyType == CurrencyType.TL)
                {
                    x.TotalCostHistory.Total *= history.ConstantsHistory.Dollar;
                    x.TotalCostHistory.FullTotal *= history.ConstantsHistory.Dollar;
                }
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
                    FullTotal = x.TotalCostHistory.FullTotal,
                    PaymentType = x.PaymentType,
                };
            });
            return Response<CalculateHistoryResponse>.Success(new CalculateHistoryResponse()
            {
                Id=id,
                Company = company.Title,
                Tanks = tanks,
                FullTotal = history.FullTotal,
                KDV = history.KDV,
                Total = history.Total,
                Constants = mapper.Map<ConstantsModel>(history.ConstantsHistory)
            }).CreateResponseInstance();
        }

    }
}
