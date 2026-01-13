using Microsoft.EntityFrameworkCore;
using ReminderApp.Data;
using ReminderApp.Dtos;
using ReminderApp.Models;

namespace ReminderApp.Services
{
    public class ReminderService : IReminderService
    {
        private readonly ReminderDbContext _dbContext;
        private readonly ILogger<ReminderService> _logger;

        public ReminderService(ReminderDbContext dbContext, ILogger<ReminderService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateReminderResponse> CreateAsync(CreateReminderRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
            {
                throw new ArgumentException("Message cannot be empty.", nameof(request.Message));
            }

            if (request.SendAt <= DateTime.UtcNow)
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

            _dbContext.Reminders.Add(reminder);
            await _dbContext.SaveChangesAsync();

            return new CreateReminderResponse(reminder.Id, reminder.Status.ToString(), reminder.SendAt);
        }

        public async Task<IEnumerable<ReminderDto>> GetAllAsync()
        {
            var reminders = await _dbContext.Reminders
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReminderDto(r))
                .ToListAsync();

            return reminders;
        }

        public async Task SendScheduledRemindersAsync(DateTime now)
        {
            var scheduledReminders = await _dbContext.Reminders
                .Where(r => r.Status == ReminderStatusEnum.Scheduled && r.SendAt <= now)
                .ToListAsync();

            foreach (var r in scheduledReminders)
            {
                r.Status = ReminderStatusEnum.Sent;
                _logger.LogInformation($"[{now:O}] Reminder sent: {r.Message}");
            }

            if (scheduledReminders.Count > 0)
            {
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
