namespace ReminderApp.Models
{
    public class Reminder
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Message { get; set; }
        public DateTimeOffset SendAt { get; set; }
        public string? Email { get; set; } = string.Empty;
        public ReminderStatusEnum Status { get; set; } = ReminderStatusEnum.Scheduled;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    public enum ReminderStatusEnum
    {
        Scheduled = 0,
        Sent,
        Failed
    }
}
