using Lpl.Compliance.Api.Data;
using Lpl.Compliance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Lpl.Compliance.Api.Repositories;

public class ComplianceCaseRepository : IComplianceCaseRepository
{
    private readonly ComplianceDbContext _context;

    public ComplianceCaseRepository(ComplianceDbContext context)
    {
        _context = context;
    }

    public async Task<object> GetDashboardAsync()
    {
        return new
        {
            totalCases = await _context.ComplianceCases.CountAsync(),
            newCases = await _context.ComplianceCases.CountAsync(x => x.Status == "New"),
            inReview = await _context.ComplianceCases.CountAsync(x => x.Status == "In Review"),
            pendingDocuments = await _context.ComplianceCases.CountAsync(x => x.Status == "Pending Documents"),
            approved = await _context.ComplianceCases.CountAsync(x => x.Status == "Approved"),
            highRisk = await _context.ComplianceCases.CountAsync(x => x.RiskScore >= 80)
        };
    }

    public async Task<object> GetCasesAsync(string? search, string? status, int pageNumber, int pageSize)
    {
        var query = _context.ComplianceCases.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.AdvisorName.Contains(search) ||
                x.ClientName.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(x => x.Status == status);
        }

        var totalRecords = await query.CountAsync();

        var data = await query
            .OrderByDescending(x => x.RiskScore)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new { totalRecords, pageNumber, pageSize, data };
    }

    public async Task<ComplianceCase?> GetByIdAsync(int id)
    {
        return await _context.ComplianceCases.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ComplianceCase?> UpdateStatusAsync(int id, string status)
    {
        var item = await _context.ComplianceCases.FirstOrDefaultAsync(x => x.Id == id);

        if (item is null)
            return null;

        item.Status = status;

        await _context.SaveChangesAsync();

        return item;
    }
}