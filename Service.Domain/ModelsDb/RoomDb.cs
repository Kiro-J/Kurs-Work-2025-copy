using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("rooms")]
    public class RoomDb
    {
        public RoomDb()
        {
            Bookings = new HashSet<BookingDb>();
            CheckInOuts = new HashSet<CheckInOutDb>();
            RoomStatuses = new HashSet<RoomStatusDb>();
            Stays = new HashSet<StayDb>();
        }

        [Key]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        [Required]
        [Column("area")]
        public decimal Area { get; set; }

        [Required]
        [Column("floor")]
        public int Floor { get; set; }

        [Required]
        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Column("price_per_night")]
        public decimal PricePerNight { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual RoomTypeDb RoomType { get; set; }
        public virtual ICollection<BookingDb> Bookings { get; set; }
        public virtual ICollection<CheckInOutDb> CheckInOuts { get; set; }
        public virtual ICollection<RoomStatusDb> RoomStatuses { get; set; }
        public virtual ICollection<StayDb> Stays { get; set; }
    }
}
