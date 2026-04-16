using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("metrics")]
    public class MetricDb
    {
        public MetricDb()
        {
            RoomTypeMetrics = new HashSet<RoomTypeMetricDb>();
        }

        [Key]
        [Column("metric_id")]
        public int MetricId { get; set; }

        [Required]
        [Column("metric_name")]
        [MaxLength(255)]
        public required string MetricName { get; set; }

        // Navigation properties
        public virtual ICollection<RoomTypeMetricDb> RoomTypeMetrics { get; set; }
    }
}
