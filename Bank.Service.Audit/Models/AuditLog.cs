using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Audit.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        public string ServiceName { get; set; }
        public int EntityId { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
