using InterviewTestProject.DataBaseComponents;
using InterviewTestProject.Enums;
using InterviewTestProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class AdditionalInfoController
    {
        private readonly ILogger<AdditionalInfoController> _logger;

        public AdditionalInfoController(ILogger<AdditionalInfoController> logger) => _logger = logger;

        [HttpGet("getDropdownTypesInfo")]
        public IEnumerable<DropdownItems> GetDropdownTypesInfo()
        {
            try
            {
                return Enum.GetValues(typeof(TagTypes)).Cast<TagTypes>().Skip(1).Select(item => new DropdownItems
                {
                    Name = Enum.GetName(typeof(TagTypes), item),
                    Value = (int)item
                }).ToArray();
            } catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _logger.LogError(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
            }

            return null;
        }

        [HttpGet("getDropdownIntervalInfo")]
        public IEnumerable<DropdownItems> GetDropdownIntervalInfo()
        {
            try
            {
                var x = Enum.GetValues(typeof(TimeInterval)).Cast<TimeInterval>().Select(item => new DropdownItems
                {
                    Name = Enum.GetName(typeof(TimeInterval), item),
                    Value = (int)item
                }).ToArray();
                return x;
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

