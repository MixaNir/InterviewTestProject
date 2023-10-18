using Azure;
using InterviewTestProject.Enums;
using InterviewTestProject.Models;
using System.Linq;

namespace InterviewTestProject.DataBaseComponents
{
    public static class DBWorker
    {
        public static IEnumerable<GraphicModel> GetGraphData(int tag = 1, int interval = 0)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tagName = Enum.GetName(typeof(TagTypes), tag).ToLower();
                var testDate = DateTime.Parse("2021-08-06 20:25:03");
                switch ((TimeInterval)interval)
                {
                    case TimeInterval.Hour:
                        return db.Events
                            .Where(item => item.RegTime >= testDate.AddHours(-1))
                            .GroupBy(p => p.RegTime.Minute)
                            .OrderBy(o => o.Key)
                            .Select(i => new GraphicModel 
                            { 
                                Name = i.Key.ToString(), 
                                CTR = Math.Round(100 * ((double)i.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / i.Count()), 4),
                                EvPM = Math.Round(1000 * ((double)i.Where(h => h.Tag != null && (h.Tag.Equals(tagName) || h.Tag.Equals("v" + tagName))).Count() / i.Count()), 4)
                            })
                            .ToArray(); 
                    case TimeInterval.Day:
                        return db.Events
                            .Where(item => item.RegTime >= testDate.AddDays(-1))
                            .GroupBy(p => p.RegTime.Hour)
                            .OrderBy(o => o.Key)
                            .Select(i => new GraphicModel 
                            { 
                                Name = i.Key.ToString(),
                                CTR = Math.Round(100 * ((double)i.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / i.Count()), 4),
                                EvPM = Math.Round(1000 * ((double)i.Where(h => h.Tag != null && (h.Tag.Equals(tagName) || h.Tag.Equals("v" + tagName))).Count() / i.Count()), 4)
                            })
                            .ToArray();
                    case TimeInterval.Week:
                        return db.Events
                            .Where(item => item.RegTime >= testDate.AddDays(-6))
                            .GroupBy(p => p.RegTime.Day)
                            .OrderBy(o => o.FirstOrDefault().RegTime)
                            .Select(i => new GraphicModel 
                            { 
                                Name = i.FirstOrDefault().RegTime.ToShortDateString(),
                                CTR = Math.Round(100 * ((double)i.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / i.Count()), 4),
                                EvPM = Math.Round(1000 * ((double)i.Where(h => h.Tag != null && (h.Tag.Equals(tagName) || h.Tag.Equals("v" + tagName))).Count() / i.Count()), 4)
                            })
                            .ToArray();
                    case TimeInterval.Month:
                        return db.Events
                            .Where(item => item.RegTime >= testDate.AddMonths(-1))
                            .GroupBy(p => p.RegTime.Day)
                            .OrderBy(o => o.FirstOrDefault().RegTime)
                            .Select(i => new GraphicModel 
                            {
                                Name = i.FirstOrDefault().RegTime.ToShortDateString(),
                                CTR = Math.Round(100 * ((double)i.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / i.Count()), 4),
                                EvPM = Math.Round(1000 * ((double)i.Where(h => h.Tag != null && (h.Tag.Equals(tagName) || h.Tag.Equals("v" + tagName))).Count() / i.Count()), 4)
                            })
                            .ToArray();
                    default:
                        return null;
                }
            }
        }

        
        public static IEnumerable<DMATableModel> GetDMATableInfo(int tagId = 1)
        {
            var tag = Enum.GetName(typeof(TagTypes), tagId).ToLower();
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Events.GroupBy(i => i.MMDma).Select(item => new DMATableModel
                {
                    DMA = item.Key,
                    Count = item.Count(),
                    CTR = Math.Round(100 * ((double)item.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / item.Count()), 4),
                    EvPM = Math.Round(1000 * ((double)item.Where(h => h.Tag != null && (h.Tag.Equals(tag) || h.Tag.Equals("v" + tag))).Count() / item.Count()), 4),
                }).ToArray();
            }

            return null;
        }
        
        public static IEnumerable<SiteTableModel> GetSiteTableInfo(int tagId = 1)
        {
            var tag = Enum.GetName(typeof(TagTypes), tagId).ToLower();
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Events.GroupBy(i => i.SiteId).Select(item => new SiteTableModel
                {
                    SiteId = item.Key,
                    Count = item.Count(),
                    CTR = Math.Round(100 * ((double)item.Where(h => h.Tag != null && h.Tag.Equals("fclick")).Count() / item.Count()), 4),
                    EvPM = Math.Round(1000 * ((double)item.Where(h => h.Tag != null && (h.Tag.Equals(tag) || h.Tag.Equals("v" + tag))).Count() / item.Count()), 4),
                }).ToArray();
            }
            return null;
        }

        public static void AddImmersions(EventModel[] events)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Events.AddRange(events);
            }
        }
        
    }
}
