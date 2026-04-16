using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("room_type_metrics")]
    public class RoomTypeMetricDb
    {
        [Key, Column(Order = 0)]
        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Key, Column(Order = 1)]
        [Column("metric_id")]
        public int MetricId { get; set; }

        // Navigation properties
        public virtual RoomTypeDb RoomType { get; set; }
        public virtual MetricDb Metric { get; set; }
    }
}
