using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("booking_controls")]
    public class BookingControlDb
    {
        [Key]
        [Column("booking_control_id")]
        public int BookingControlId { get; set; }

        [Required]
        [Column("booking_id")]
        public int BookingId { get; set; }

        [Required]
        [Column("control_date")]
        public DateTime ControlDate { get; set; }

        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual BookingDb Booking { get; set; }
    }
}
