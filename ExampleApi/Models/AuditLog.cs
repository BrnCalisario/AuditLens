using Audit.EntityFramework;

namespace ExampleApi.Models
{
    [AuditIgnore]
    public class AuditLog
    {
        public long AuditId { get; set; }
        public string TableName { get; set; } = null!;
        public string AuditUser { get; set; } = null!;
        public string AuditAction { get; set; } = null!;
        public string AuditData { get; set; } = null!;
        public DateTimeOffset AuditDate = DateTimeOffset.Now;
    }
}