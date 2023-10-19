using InterviewTestProject.DataBaseComponents;
using InterviewTestProject.Enums;
using InterviewTestProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsVisualizerController : ControllerBase
    {
        private readonly ILogger<MetricsVisualizerController> _logger;
        private readonly ApplicationContext _context;

        public MetricsVisualizerController(ILogger<MetricsVisualizerController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getGraphData/{tag}/{interval}")]
        public IEnumerable<GraphicModel> GetGraphData(int tag, int interval)
        {
            try
            {
                return DBWorker.GetGraphData(_context, tag, interval);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _logger.LogError(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
            }

            return null;
        }
    }
}