using Logging_System.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logging_System.Models;

namespace Logging_System.Controllers
{
    [ApiController]
    [Route("v1/logs")]
    public class LogsController : ControllerBase
    {
        private readonly ILogStorage _logService;

        public LogsController(ILogStorage logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogEntry log)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid log data.");

            await _logService.StoreLogAsync(log);
            return Ok("Log saved successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs([FromQuery] string? service, [FromQuery] string? level,
                                                 [FromQuery] DateTime? start_time, [FromQuery] DateTime? end_time)
        {
            var logs = await _logService.RetrieveLogsAsync(service, level, start_time, end_time);
            return Ok(logs);
        }
    }

}
