using Microsoft.AspNetCore.Mvc;
using ReminderApp.Dtos;
using ReminderApp.Services;

namespace ReminderApp.Controllers
{
    [Route("api/reminders")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateReminderResponse>> Create([FromBody] CreateReminderRequest request)
        {
            try
            {
                var reminder = await _reminderService.CreateAsync(request);

                return Created("/reminders", reminder);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReminderDto>>> GetAll()
        {
           var reminders = await _reminderService.GetAllAsync();

            return Ok(reminders);
        }
    }
}
