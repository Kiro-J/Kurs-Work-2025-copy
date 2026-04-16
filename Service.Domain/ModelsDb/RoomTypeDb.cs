using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("room_types")]
    public class RoomTypeDb
    {
        public RoomTypeDb()
        {
            Rooms = new HashSet<RoomDb>();
            RoomTypeMetrics = new HashSet<RoomTypeMetricDb>();
        }

        [Key]
        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Required]
        [Column("type_name")]
        [MaxLength(100)]
        public required string TypeName { get; set; }

        // Navigation properties
        public virtual ICollection<RoomDb> Rooms { get; set; }
        public virtual ICollection<RoomTypeMetricDb> RoomTypeMetrics { get; set; }
    }
}
