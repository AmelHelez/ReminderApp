using System.ComponentModel.DataAnnotations;

namespace ReminderApp.Dtos
{
    public class CreateReminderRequest
    {
        [Required]
        [MinLength(2)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public DateTime SendAt { get; set; } = DateTime.UtcNow;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
