using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("services")]
    public class ServiceDb
    {
        public ServiceDb()
        {
            StayServices = new HashSet<StayServiceDb>();
        }

        [Key]
        [Column("service_id")]
        public int ServiceId { get; set; }

        [Required]
        [Column("service_name")]
        [MaxLength(255)]
        public required string ServiceName { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        // Navigation properties
        public virtual ICollection<StayServiceDb> StayServices { get; set; }
    }
}
