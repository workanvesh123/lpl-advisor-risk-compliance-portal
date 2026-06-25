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
    public IActionResult GetDashboard()
    {
        return Ok(_service.GetDashboard());
    }

    [HttpGet]
    public IActionResult GetCases(string? search, string? status, int pageNumber = 1, int pageSize = 10)
    {
        return Ok(_service.GetCases(search, status, pageNumber, pageSize));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCaseById(int id)
    {
        var item = _service.GetById(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPut("{id:int}/status")]
    public IActionResult UpdateStatus(int id, UpdateStatusRequest request)
    {
        var item = _service.UpdateStatus(id, request.Status);
        return item is null ? NotFound() : Ok(item);
    }
}