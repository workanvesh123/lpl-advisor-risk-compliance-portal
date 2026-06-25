using Lpl.Compliance.Api.Models;

namespace Lpl.Compliance.Api.Repositories;

public interface IComplianceCaseRepository
{
    Task<object> GetDashboardAsync();
    Task<object> GetCasesAsync(string? search, string? status, int pageNumber, int pageSize);
    Task<ComplianceCase?> GetByIdAsync(int id);
    Task<ComplianceCase?> UpdateStatusAsync(int id, string status);
}