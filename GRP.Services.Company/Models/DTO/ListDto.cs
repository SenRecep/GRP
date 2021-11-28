using GRP.Core.Interfaces;

namespace GRP.Services.Company.Models.DTO;

public record ListDto : ICompany,IDTO
{
    public Guid Id { get; set; }    
    public string? Title { get; set; }
    public string? CurrentAccountCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Mail { get; set; }
    public string? Address { get; set; }
    public string? TaxAdministration { get; set; }
    public string? TaxNumber { get; set; }
    public string? AuthorizedPerson { get; set; }
}
