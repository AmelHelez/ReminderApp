using ReminderApp.Dtos;
namespace ReminderApp.Services
{
    public interface IReminderService
    {
        Task<CreateReminderResponse> CreateAsync(CreateReminderRequest request);
        Task<IEnumerable<ReminderDto>> GetAllAsync();
        Task SendScheduledRemindersAsync(DateTime now);
    }
}
