using Lpl.Compliance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Lpl.Compliance.Api.Data;

public class ComplianceDbContext : DbContext
{
    public ComplianceDbContext(DbContextOptions<ComplianceDbContext> options)
        : base(options)
    {
    }

    public DbSet<ComplianceCase> ComplianceCases => Set<ComplianceCase>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComplianceCase>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.AdvisorName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.ClientName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Status)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.RiskScore);
            entity.HasIndex(x => x.CreatedDate);

            entity.HasData(
                new ComplianceCase { Id = 1, AdvisorName = "Ravi Kumar", ClientName = "John Smith", RiskScore = 82, Status = "New", CreatedDate = new DateTime(2026, 6, 23) },
                new ComplianceCase { Id = 2, AdvisorName = "Priya Sharma", ClientName = "Mary Johnson", RiskScore = 45, Status = "In Review", CreatedDate = new DateTime(2026, 6, 20) },
                new ComplianceCase { Id = 3, AdvisorName = "Anil Reddy", ClientName = "Robert Brown", RiskScore = 91, Status = "Pending Documents", CreatedDate = new DateTime(2026, 6, 24) },
                new ComplianceCase { Id = 4, AdvisorName = "Sneha Rao", ClientName = "Linda Davis", RiskScore = 30, Status = "Approved", CreatedDate = new DateTime(2026, 6, 15) }
            );
        });
    }
}