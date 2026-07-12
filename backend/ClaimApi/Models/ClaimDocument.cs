using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimApi.Models
{
    [Table("claimdocuments")]
    public class ClaimDocument
    {
        [Key]
        [Column("doc_id")]
        public int DocId { get; set; }

        [Column("claim_id")]
        public int ClaimId { get; set; }

        [Column("file_url")]
        public string? FileUrl { get; set; }
    }
}