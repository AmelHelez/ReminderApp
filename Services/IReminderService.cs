using ReminderApp.Dtos;

namespace ReminderApp.Services
{
    public interface IReminderService
    {
        CreateReminderResponse Create(CreateReminderRequest request);
        IReadOnlyList<ReminderDto> GetAll();
    }
}
