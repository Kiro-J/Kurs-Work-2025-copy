using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.ModelsDb
{
    [Table("users")]
    public class UserDb
    {
        public UserDb()
        {
            Bookings = new HashSet<BookingDb>();
            CheckInOuts = new HashSet<CheckInOutDb>();
            Messages = new HashSet<MessageDb>();
        }

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        public required string Email { get; set; }

        [Required]
        [Column("password_hash")]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }

        [Column("role")]
        [MaxLength(20)]
        public string Role { get; set; } = "guest";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<BookingDb> Bookings { get; set; }
        public virtual ICollection<CheckInOutDb> CheckInOuts { get; set; }
        public virtual ICollection<MessageDb> Messages { get; set; }
    }
}
