using ReminderApp.Models;

namespace ReminderApp.Dtos
{
    public sealed class ReminderDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string SendAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Email { get; set; }

        public ReminderDto(Reminder r)
        {
            Id = r.Id;
            Message = r.Message;
            SendAt = r.SendAt.ToString("yyyy-MM-ddTHH:mm:ssZ");
            Status = r.Status.ToString();
            Email = r.Email;
        }
    }
}
