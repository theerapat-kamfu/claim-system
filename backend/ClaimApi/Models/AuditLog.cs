using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ClaimApi.Models
{
    [Table("audit_logs")]
    public class AuditLog
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }

        [Column("changed_by")]
        public int ChangedBy { get; set; }

        [Column("changed_at")]
        public DateTime ChangedAt { get; set; }

        [Column("record_id")]
        public int RecordId { get; set; }

        [Column("old_value")]
        public JsonDocument? OldValue { get; set; }

        [Column("new_value")]
        public JsonDocument? NewValue { get; set; }

        [Column("table_name")]
        public string TableName { get; set; }

        [Column("action")]
        public string Action { get; set; }
    }
}