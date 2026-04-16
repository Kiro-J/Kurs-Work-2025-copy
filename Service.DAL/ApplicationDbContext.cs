using Microsoft.EntityFrameworkCore;
using Service.Domain.ModelsDb;

namespace Service.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }
        public DbSet<RoomTypeDb> RoomTypes { get; set; }
        public DbSet<MetricDb> Metrics { get; set; }
        public DbSet<RoomTypeMetricDb> RoomTypeMetrics { get; set; }
        public DbSet<RoomDb> Rooms { get; set; }
        public DbSet<BookingDb> Bookings { get; set; }
        public DbSet<BookingControlDb> BookingControls { get; set; }
        public DbSet<CheckInOutDb> CheckInOuts { get; set; }
        public DbSet<RoomStatusDb> RoomStatuses { get; set; }
        public DbSet<ServiceDb> Services { get; set; }
        public DbSet<StayDb> Stays { get; set; }
        public DbSet<StayServiceDb> StayServices { get; set; }
        public DbSet<MessageDb> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Bookings (One-to-Many)
            modelBuilder.Entity<UserDb>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> CheckInOuts (One-to-Many)
            modelBuilder.Entity<UserDb>()
                .HasMany(u => u.CheckInOuts)
                .WithOne(c => c.ProcessedByUser)
                .HasForeignKey(c => c.ProcessedBy)
                .OnDelete(DeleteBehavior.SetNull);

            // User -> Messages (One-to-Many)
            modelBuilder.Entity<UserDb>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // RoomType -> Rooms (One-to-Many)
            modelBuilder.Entity<RoomTypeDb>()
                .HasMany(rt => rt.Rooms)
                .WithOne(r => r.RoomType)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // RoomType -> RoomTypeMetrics (One-to-Many)
            modelBuilder.Entity<RoomTypeDb>()
                .HasMany(rt => rt.RoomTypeMetrics)
                .WithOne(rtm => rtm.RoomType)
                .HasForeignKey(rtm => rtm.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Metric -> RoomTypeMetrics (One-to-Many)
            modelBuilder.Entity<MetricDb>()
                .HasMany(m => m.RoomTypeMetrics)
                .WithOne(rtm => rtm.Metric)
                .HasForeignKey(rtm => rtm.MetricId)
                .OnDelete(DeleteBehavior.Cascade);

            // Room -> Bookings (One-to-Many)
            modelBuilder.Entity<RoomDb>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomNumber)
                .OnDelete(DeleteBehavior.Restrict);

            // Room -> CheckInOuts (One-to-Many)
            modelBuilder.Entity<RoomDb>()
                .HasMany(r => r.CheckInOuts)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomNumber)
                .OnDelete(DeleteBehavior.Restrict);

            // Room -> RoomStatuses (One-to-Many)
            modelBuilder.Entity<RoomDb>()
                .HasMany(r => r.RoomStatuses)
                .WithOne(rs => rs.Room)
                .HasForeignKey(rs => rs.RoomNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // Room -> Stays (One-to-Many)
            modelBuilder.Entity<RoomDb>()
                .HasMany(r => r.Stays)
                .WithOne(s => s.Room)
                .HasForeignKey(s => s.RoomNumber)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> BookingControls (One-to-Many)
            modelBuilder.Entity<BookingDb>()
                .HasMany(b => b.BookingControls)
                .WithOne(bc => bc.Booking)
                .HasForeignKey(bc => bc.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking -> Stays (One-to-Many)
            modelBuilder.Entity<BookingDb>()
                .HasMany(b => b.Stays)
                .WithOne(s => s.Booking)
                .HasForeignKey(s => s.BookingId)
                .OnDelete(DeleteBehavior.SetNull);

            // Stay -> StayServices (One-to-Many)
            modelBuilder.Entity<StayDb>()
                .HasMany(s => s.StayServices)
                .WithOne(ss => ss.Stay)
                .HasForeignKey(ss => ss.StayId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service -> StayServices (One-to-Many)
            modelBuilder.Entity<ServiceDb>()
                .HasMany(s => s.StayServices)
                .WithOne(ss => ss.Service)
                .HasForeignKey(ss => ss.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
