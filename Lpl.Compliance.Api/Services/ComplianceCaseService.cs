using Lpl.Compliance.Api.Models;

namespace Lpl.Compliance.Api.Services;

public class ComplianceCaseService
{
    private static readonly List<ComplianceCase> Cases =
    [
        new() { Id = 1, AdvisorName = "Ravi Kumar", ClientName = "John Smith", RiskScore = 82, Status = "New", CreatedDate = DateTime.Today.AddDays(-2) },
        new() { Id = 2, AdvisorName = "Priya Sharma", ClientName = "Mary Johnson", RiskScore = 45, Status = "In Review", CreatedDate = DateTime.Today.AddDays(-5) },
        new() { Id = 3, AdvisorName = "Anil Reddy", ClientName = "Robert Brown", RiskScore = 91, Status = "Pending Documents", CreatedDate = DateTime.Today.AddDays(-1) },
        new() { Id = 4, AdvisorName = "Sneha Rao", ClientName = "Linda Davis", RiskScore = 30, Status = "Approved", CreatedDate = DateTime.Today.AddDays(-10) }
    ];

    public object GetDashboard() => new
    {
        totalCases = Cases.Count,
        newCases = Cases.Count(x => x.Status == "New"),
        inReview = Cases.Count(x => x.Status == "In Review"),
        pendingDocuments = Cases.Count(x => x.Status == "Pending Documents"),
        approved = Cases.Count(x => x.Status == "Approved"),
        highRisk = Cases.Count(x => x.RiskScore >= 80)
    };

    public object GetCases(string? search, string? status, int pageNumber, int pageSize)
    {
        var query = Cases.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.AdvisorName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                x.ClientName.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(x => x.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        var totalRecords = query.Count();

        var data = query
            .OrderByDescending(x => x.RiskScore)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new { totalRecords, pageNumber, pageSize, data };
    }

    public ComplianceCase? GetById(int id)
    {
        return Cases.FirstOrDefault(x => x.Id == id);
    }

    public ComplianceCase? UpdateStatus(int id, string status)
    {
        var item = Cases.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return null;

        item.Status = status;
        return item;
    }
}