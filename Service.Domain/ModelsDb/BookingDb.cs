using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("bookings")]
    public class BookingDb
    {
        public BookingDb()
        {
            BookingControls = new HashSet<BookingControlDb>();
        }

        [Key]
        [Column("booking_id")]
        public int BookingId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("booking_date")]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow.Date;

        [Required]
        [Column("guest_count")]
        public int GuestCount { get; set; }

        [Required]
        [Column("check_in_date")]
        public DateTime CheckInDate { get; set; }

        [Column("booking_info")]
        public string? BookingInfo { get; set; }

        [Required]
        [Column("check_out_date")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        [Column("total_price")]
        public decimal? TotalPrice { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; } = "pending";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual UserDb User { get; set; }
        public virtual RoomDb Room { get; set; }
        public virtual ICollection<BookingControlDb> BookingControls { get; set; }
    }
}
