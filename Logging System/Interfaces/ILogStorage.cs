using Logging_System.Models;

namespace Logging_System.Interfaces
{
    public interface ILogStorage
    {
        Task StoreLogAsync(LogEntry log);
        Task<IEnumerable<LogEntry>> RetrieveLogsAsync(string? service, string? level, DateTime? startTime, DateTime? endTime);
    }
}
