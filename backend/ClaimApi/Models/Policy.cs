using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimApi.Models
{
    [Table("policies")]
    public class Policy
    {
        [Key]
        [Column("policy_id")]
        public int PolicyId { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("policy_number")]
        public string? PolicyNumber { get; set; }
    }
}