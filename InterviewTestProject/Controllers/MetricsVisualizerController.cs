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

        public MetricsVisualizerController(ILogger<MetricsVisualizerController> logger) => _logger = logger;

        [HttpGet("getGraphData/{tag}/{interval}")]
        public IEnumerable<GraphicModel> GetGraphData(int tag, int interval)
        {
            try
            {
                return DBWorker.GetGraphData(tag, interval);
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