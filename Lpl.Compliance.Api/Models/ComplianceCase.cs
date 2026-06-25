namespace Lpl.Compliance.Api.Models;

public class ComplianceCase
{
    public int Id { get; set; }
    public string AdvisorName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public int RiskScore { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}