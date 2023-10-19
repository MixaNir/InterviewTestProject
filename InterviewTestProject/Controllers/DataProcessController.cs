using InterviewTestProject.DataBaseComponents;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataProcessController: ControllerBase
    {
        private readonly ILogger<DataProcessController> _logger;
        private readonly ApplicationContext _context;

        public DataProcessController(ILogger<DataProcessController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public ActionResult<EventModel> CreateEmployee(EventModel[] events)
        {
            try
            {
                if (events == null)
                    return BadRequest();

                DBWorker.AddImmersions(_context, events);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _logger.LogError(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");

            }
        }
    }


}
