

namespace Logging_System.Models
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        public string Service { get; set; }
        public string Level { get; set; } // info, warning, error
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string StorageType { get; set; } // Metadata: S3, DB, File
    }
}
