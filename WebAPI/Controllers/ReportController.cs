using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("getreportdetails")]
    public IActionResult GetEmployeeDetails()
    {
        var result = _reportService.GetReportDetails();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}