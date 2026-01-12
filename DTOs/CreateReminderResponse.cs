namespace ReminderApp.Dtos
{
    public sealed class CreateReminderResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string SendAt { get; set; } = string.Empty;

        public CreateReminderResponse(Guid id, string status, DateTimeOffset sendAt)
        {
            Id = id;
            Status = status;
            SendAt = sendAt.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
