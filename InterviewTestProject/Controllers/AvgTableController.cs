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
        private readonly ApplicationContext _context;

        public AvgTableController(ILogger<AvgTableController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getDMAInfo/{tagType}")]
        public IEnumerable<DMATableModel> GetDMA(int tagType)
        {
            try
            {
                return DBWorker.GetDMATableInfo(_context, tagType);
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
                return DBWorker.GetSiteTableInfo(_context, tagType);
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

