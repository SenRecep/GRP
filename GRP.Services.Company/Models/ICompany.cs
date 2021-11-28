namespace GRP.Services.Company.Models;

public interface ICompany
{
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
