using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("stays")]
    public class StayDb
    {
        public StayDb()
        {
            StayServices = new HashSet<StayServiceDb>();
        }

        [Key]
        [Column("stay_id")]
        public int StayId { get; set; }

        [Column("booking_id")]
        public int? BookingId { get; set; }

        [Required]
        [Column("stay_date")]
        public DateTime StayDate { get; set; }

        [Required]
        [Column("guest_count")]
        public int GuestCount { get; set; }

        [Required]
        [Column("check_in_date")]
        public DateTime CheckInDate { get; set; }

        [Column("stay_info")]
        public string? StayInfo { get; set; }

        [Required]
        [Column("check_out_date")]
        public DateTime CheckOutDate { get; set; }

        [Column("total_cost")]
        public decimal? TotalCost { get; set; }

        [Required]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; } = "active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual BookingDb? Booking { get; set; }
        public virtual RoomDb Room { get; set; }
        public virtual ICollection<StayServiceDb> StayServices { get; set; }
    }
}
