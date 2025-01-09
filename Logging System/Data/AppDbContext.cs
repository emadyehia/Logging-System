using Microsoft.EntityFrameworkCore;
using Logging_System.Models;
namespace Logging_System.Data
{
    

    public class AppDbContext : DbContext
    {
        public DbSet<LogEntry> LogEntries { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntry>().HasKey(log => log.Id);
            modelBuilder.Entity<LogEntry>().Property(log => log.Service).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(log => log.Level).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(log => log.Timestamp).IsRequired();
        }
    }

}
