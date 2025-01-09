using Logging_System.Interfaces;
using Logging_System.Models;
namespace Logging_System.Classes
{
    public class LogService : ILogStorage
    {
        private readonly ILogStorage _storage;

        public LogService(ILogStorage storage)
        {
            _storage = storage;
        }

        public async Task StoreLogAsync(LogEntry log)
        {
            await _storage.StoreLogAsync(log);
        }

        public async Task<IEnumerable<LogEntry>> RetrieveLogsAsync(string? service, string? level, DateTime? startTime, DateTime? endTime)
        {
            return await _storage.RetrieveLogsAsync(service, level, startTime, endTime);
        }
    }

}
