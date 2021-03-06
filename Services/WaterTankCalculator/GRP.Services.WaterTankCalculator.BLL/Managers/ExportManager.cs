#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using GRP.Services.WaterTankCalculator.Entities.Enums;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using SelectPdf;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class ExportManager : IExportService
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly WaterTankCalculatorDbContext context;
    private readonly ICompanyService companyService;

    public ExportManager(IWebHostEnvironment webHostEnvironment, WaterTankCalculatorDbContext context, ICompanyService companyService)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.context = context;
        this.companyService = companyService;
    }
    public async Task CreateAsync(Guid id)
    {
        var templatePath = Path.Combine(webHostEnvironment.WebRootPath, "Templates", "withbootstrap.html");
        var htmlContent = File.ReadAllText(templatePath);
        var path = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{id}.pdf");
        var history = await context.CalculationHistories
            .Include(x => x.CalculateModelHistories)
            .ThenInclude(x => x.TotalCostHistory)
            .Include(x => x.CalculateModelHistories)
            .ThenInclude(x => x.EdgeModelHistory)
            .FirstOrDefaultAsync(x => x.Id == id);
        var company = await companyService.GetByIdAsync(history.CompnyId.Value);
        var rows = history.CalculateModelHistories.Select(x =>
        {
            var type = x.PlinthType == PlinthType.Flat ? "Düz Kaide" : "Kriş Kaide";
            if (history.CurrencyType==CurrencyType.TL)
            {
                x.TotalCostHistory.Total *= history.ConstantsHistory.Dollar;
                x.TotalCostHistory.FullTotal *= history.ConstantsHistory.Dollar;
            }
            return $"<tr><td>{type}</td><td>{x.EdgeModelHistory.Capacity}m3</td><td>{x.Width}</td><td>{x.Length}</td><td>{x.Height}</td><td>GRP KOMPOZİT</td><td>{x.Quantity}</td><td>{x.TotalCostHistory.Total}$</td><td>{x.TotalCostHistory.FullTotal}$</td></tr>";
        });
        if (history.CurrencyType == CurrencyType.TL)
        {
            history.Total *= history.ConstantsHistory.Dollar;
            history.FullTotal *= history.ConstantsHistory.Dollar;
            history.KDV *= history.ConstantsHistory.Dollar;
        }
        var tableRows = string.Join("", rows);
        var currency = history.CurrencyType == CurrencyType.TL ? "₺" : "$";
        htmlContent = htmlContent
            .Replace("{123123}", $"{ history.No}")
            .Replace("{date}", DateTime.Now.ToShortDateString())
            .Replace("{kdv}", $"{history.KDV}$")
            .Replace("{subtotal}", $"{history.Total}$")
            .Replace("{total}", $"{history.FullTotal}$")
            .Replace("{firmName}", $"{company.Title}")
            .Replace("{firmNo}", $"{company.CurrentAccountCode}")
            .Replace("{vd}", $"{company.TaxAdministration}")
            .Replace("{vn}", $"{company.TaxNumber}")
            .Replace("{adress}", $"{company.Address}")
            .Replace("{firmPerson}", $"{company.AuthorizedPerson}")
            .Replace("{firmMail}", $"{company.Mail}")
            .Replace("{firmPhone}", $"{company.Phone}")
            .Replace("{rows}", $"{tableRows}")
            .Replace("$", $"{currency}");

        HtmlToPdf converter = new();
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
        PdfDocument doc = converter.ConvertHtmlString(htmlContent);
        var fs = new FileStream(path,FileMode.Create,FileAccess.Write);
        doc.Save(fs);
        doc.Close();
        fs.Close();
    }
}
