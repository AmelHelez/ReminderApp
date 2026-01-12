using System.ComponentModel.DataAnnotations;

namespace ReminderApp.Dtos
{
    public class CreateReminderRequest
    {
        [Required]
        [MinLength(2)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public DateTimeOffset SendAt { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
