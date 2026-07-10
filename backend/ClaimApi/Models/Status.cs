using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimApi.Models
{
    [Table("master_status")]
    public class Status
    {
        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }

        [Column("status_name")]
        public string StatusName { get; set; }
    }
}