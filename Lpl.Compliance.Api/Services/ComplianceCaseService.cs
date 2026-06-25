using Lpl.Compliance.Api.Models;
using Lpl.Compliance.Api.Repositories;

namespace Lpl.Compliance.Api.Services;

public class ComplianceCaseService
{
    private readonly IComplianceCaseRepository _repository;

    public ComplianceCaseService(IComplianceCaseRepository repository)
    {
        _repository = repository;
    }

    public Task<object> GetDashboardAsync()
    {
        return _repository.GetDashboardAsync();
    }

    public Task<object> GetCasesAsync(string? search, string? status, int pageNumber, int pageSize)
    {
        return _repository.GetCasesAsync(search, status, pageNumber, pageSize);
    }

    public Task<ComplianceCase?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<ComplianceCase?> UpdateStatusAsync(int id, string status)
    {
        return _repository.UpdateStatusAsync(id, status);
    }
}