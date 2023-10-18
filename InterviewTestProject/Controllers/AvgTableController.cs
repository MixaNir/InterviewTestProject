using InterviewTestProject.DataBaseComponents;
using InterviewTestProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvgTableController : ControllerBase
    {
        private readonly ILogger<AvgTableController> _logger;

        public AvgTableController(ILogger<AvgTableController> logger) => _logger = logger;

        [HttpGet("getDMAInfo/{tagType}")]
        public IEnumerable<DMATableModel> GetDMA(int tagType)
        {
            try
            {
                return DBWorker.GetDMATableInfo(tagType);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _logger.LogError(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
            }

            return null;
        }

        [HttpGet("getSiteInfo/{tagType}")]
        public IEnumerable<SiteTableModel> GetSIte(int tagType)
        {
            try
            {
                return DBWorker.GetSiteTableInfo(tagType);
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

