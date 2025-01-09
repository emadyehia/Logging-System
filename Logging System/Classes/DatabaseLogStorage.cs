using System;
using Logging_System.Data;
using Logging_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Logging_System.Interfaces;

namespace Logging_System.Classes
{
    public class DatabaseLogStorage : ILogStorage
    {
        private readonly AppDbContext _context;

        public DatabaseLogStorage(AppDbContext context)
        {
            _context = context;
        }

        public async Task StoreLogAsync(LogEntry log)
        {
            await _context.LogEntries.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LogEntry>> RetrieveLogsAsync(string? service, string? level, DateTime? startTime, DateTime? endTime)
        {
            return await _context.LogEntries
                .Where(log =>
                    (service == null || log.Service == service) &&
                    (level == null || log.Level == level) &&
                    (!startTime.HasValue || log.Timestamp >= startTime) &&
                    (!endTime.HasValue || log.Timestamp <= endTime))
                .ToListAsync();
        }
    }
}
