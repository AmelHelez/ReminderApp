namespace ReminderApp.Dtos
{
    public sealed class CreateReminderResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string SendAt { get; set; } = string.Empty;

        public CreateReminderResponse(Guid id, string status, DateTime sendAt)
        {
            Id = id;
            Status = status;
            SendAt = sendAt.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
