using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("room_status")]
    public class RoomStatusDb
    {
        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }

        [Required]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        [Required]
        [Column("status_datetime")]
        public DateTime StatusDateTime { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }

        // Navigation properties
        public virtual RoomDb Room { get; set; }
    }
}
