using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogController : ControllerBase
    {
        ITimeLogService _timeLogService;

        public TimeLogController(ITimeLogService timeLogService)
        {
            _timeLogService = timeLogService;
        }

        [HttpGet("gettimelogdetails")]
        public IActionResult GetEmployeeDetails()
        {
            var result = _timeLogService.GetTimeLogDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
