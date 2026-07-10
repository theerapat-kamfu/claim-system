using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimApi.Models
{
    [Table("master_rejectreasons")]
    public class RejectReason
    {
        [Key]
        [Column("reason_id")]
        public int ReasonId { get; set; }

        [Column("reason_name")]
        public string ReasonName { get; set; }
    }
}