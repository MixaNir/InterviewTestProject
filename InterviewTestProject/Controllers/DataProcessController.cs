using InterviewTestProject.DataBaseComponents;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataProcessController: ControllerBase
    {
        private readonly ILogger<DataProcessController> _logger;

        public DataProcessController(ILogger<DataProcessController> logger) => _logger = logger;

        [HttpPost]
        public ActionResult<EventModel> CreateEmployee(EventModel[] events)
        {
            try
            {
                if (events == null)
                    return BadRequest();

                DBWorker.AddImmersions(events);

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
