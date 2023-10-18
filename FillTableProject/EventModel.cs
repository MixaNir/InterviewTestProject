using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FillTableProject
{
    [Index("MMDma")]
    [Index("SiteId")]
    public class EventModel
    {
        public DateTime RegTime { get; set; }

        [Key]
        public Guid UID { get; set; }

        public int FcImpChk { get; set; }

        public int FcTimeChk { get; set; }

        public int Utmtr { get; set; }

        public int MMDma { get; set; }

        public string OsName { get; set; }

        public string Model { get; set; }

        public string Hardware { get; set; }

        public string SiteId { get; set; }

        public string? Tag { get; set; }
    }
}
