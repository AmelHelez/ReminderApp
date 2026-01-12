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
        public ActionResult<CreateReminderResponse> Create([FromBody] CreateReminderRequest request)
        {
            try
            {
                var reminder = _reminderService.Create(request);

                return Created("/reminders", reminder);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_reminderService.GetAll());
        }
    }
}
