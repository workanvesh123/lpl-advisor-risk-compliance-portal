using Lpl.Compliance.Api.Models;
using Lpl.Compliance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lpl.Compliance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CasesController : ControllerBase
{
    private readonly ComplianceCaseService _service;

    public CasesController(ComplianceCaseService service)
    {
        _service = service;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        return Ok(await _service.GetDashboardAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetCases(string? search, string? status, int pageNumber = 1, int pageSize = 10)
    {
        return Ok(await _service.GetCasesAsync(search, status, pageNumber, pageSize));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCaseById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateStatusRequest request)
    {
        var item = await _service.UpdateStatusAsync(id, request.Status);
        return item is null ? NotFound() : Ok(item);
    }
}