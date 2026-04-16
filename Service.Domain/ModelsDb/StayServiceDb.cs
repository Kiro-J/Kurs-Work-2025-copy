using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("stay_services")]
    public class StayServiceDb
    {
        [Key, Column(Order = 0)]
        [Column("stay_id")]
        public int StayId { get; set; }

        [Key, Column(Order = 1)]
        [Column("service_id")]
        public int ServiceId { get; set; }

        [Required]
        [Column("service_cost")]
        public decimal ServiceCost { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } = 1;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual StayDb Stay { get; set; }
        public virtual ServiceDb Service { get; set; }
    }
}
