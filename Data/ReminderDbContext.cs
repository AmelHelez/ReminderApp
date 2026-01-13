using Microsoft.EntityFrameworkCore;
using ReminderApp.Models;

namespace ReminderApp.Data
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions<ReminderDbContext> options) : base(options) {}

        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1000);
                entity.Property(e => e.Email)
                .HasDefaultValue(string.Empty)
                .HasMaxLength(255);
                entity.Property(e => e.Status)
                .IsRequired();
            });
        }
    }
}
