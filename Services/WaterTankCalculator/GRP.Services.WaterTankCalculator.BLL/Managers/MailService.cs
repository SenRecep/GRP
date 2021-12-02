#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Settings;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Response;
using GRP.Shared.DAL.Interfaces;

using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.AspNetCore.Hosting;

using MimeKit;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class MailService : IMailService
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IGenericQueryRepository<CalculationHistory> calculationHistoryRepository;
    private readonly IMailSettings mailSettings;
    private readonly ICompanyService companyService;

    public MailService(
        IWebHostEnvironment webHostEnvironment,
        IGenericQueryRepository<CalculationHistory> calculationHistoryRepository,
        IMailSettings mailSettings,
        ICompanyService companyService)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.calculationHistoryRepository = calculationHistoryRepository;
        this.mailSettings = mailSettings;
        this.companyService = companyService;
    }
    public async Task<Response<string>> SendAsync(Guid id)
    {
        var calculationHistory = await calculationHistoryRepository.GetByIdAsync(id);
        var company = await companyService.GetByIdAsync(calculationHistory.CompnyId.Value);
        if (company.Mail.IsEmpty())
            return Response<string>.Fail(400, true, "/mailservice", "İlgili firmanın mail bilgileri eksik veya hatalı");
        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Templates", "MailTemplate.html");
        string attachmentPath = Path.Combine(webHostEnvironment.WebRootPath, "exports", $"{id}.html");
        string MailText = await File.ReadAllTextAsync(filePath);
        var attachment = File.OpenRead(attachmentPath);
        MimeMessage email = new()
        {
            Sender = MailboxAddress.Parse(mailSettings.Mail)
        };
        email.To.Add(MailboxAddress.Parse(company.Mail));
        email.Subject = $"Aksu Depo Fiyat Teklifi";
        BodyBuilder builder = new()
        {
            HtmlBody = MailText
        };

        builder.Attachments.Add("Fiyat Teklifi.html", attachment, ContentType.Parse("text/html"));
        email.Body = builder.ToMessageBody();
        using SmtpClient smtp = new();
        smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
        return Response<string>.Success();
    }
}
