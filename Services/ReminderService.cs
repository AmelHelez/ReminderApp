using ReminderApp.Dtos;
using ReminderApp.Models;

namespace ReminderApp.Services
{
    public class ReminderService : IReminderService
    {
        private readonly List<Reminder> _reminders = [];

        public ReminderService()
        {
            
        }

        public CreateReminderResponse Create(CreateReminderRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
            {
                throw new ArgumentException("Message cannot be empty.", nameof(request.Message));
            }

            if (request.SendAt <= DateTimeOffset.UtcNow)
            {
                throw new ArgumentException("Send at must be in the future.", nameof(request.SendAt));
            }

            var reminder = new Reminder
            {
                Message = request.Message.Trim(),
                SendAt = request.SendAt,
                Email = string.IsNullOrWhiteSpace(request.Email) ? string.Empty : request.Email.Trim(),
                Status = ReminderStatusEnum.Scheduled
            };

            _reminders.Add(reminder);

            return new CreateReminderResponse(reminder.Id, reminder.Status.ToString(), reminder.SendAt);
        }

        public IReadOnlyList<ReminderDto> GetAll()
        {
            return _reminders.Select(r => new ReminderDto(r)).ToList();
        }
    }
}
