using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimApi.Models
{
    [Table("claims")]
    public class Claim
    {
        [Key]
        [Column("claim_id")]
        public int ClaimId { get; set; }

        [Column("policy_id")]
        public int PolicyId { get; set; }

        [Column("status_id")]
        public int StatusId { get; set; }

        [Column("reject_reason_id")]
        public int? RejectReasonId { get; set; }

        [Column("claim_amount")]
        public decimal ClaimAmount { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}