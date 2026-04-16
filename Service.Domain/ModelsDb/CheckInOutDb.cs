using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("check_in_out")]
    public class CheckInOutDb
    {
        [Key]
        [Column("check_id")]
        public int CheckId { get; set; }

        [Required]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        [Required]
        [Column("event_date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Column("guest_count")]
        public int GuestCount { get; set; }

        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }

        [Column("processed_by")]
        public int? ProcessedBy { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual RoomDb Room { get; set; }
        public virtual UserDb? ProcessedByUser { get; set; }
    }
}
