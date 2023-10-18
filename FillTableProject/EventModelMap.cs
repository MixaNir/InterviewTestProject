using CsvHelper.Configuration;

namespace FillTableProject
{
    public sealed class EventModelMap: ClassMap<EventModel>
    {
        public EventModelMap()
        {
            Map(m => m.RegTime).Name("reg_time");
            Map(m => m.UID).Name("uid");
            Map(m => m.FcImpChk).Name("fc_imp_chk");
            Map(m => m.FcTimeChk).Name("fc_time_chk");
            Map(m => m.Utmtr).Name("utmtr");
            Map(m => m.MMDma).Name("mm_dma");
            Map(m => m.OsName).Name("osName");
            Map(m => m.Model).Name("model");
            Map(m => m.Hardware).Name("hardware");
            Map(m => m.SiteId).Name("site_id");
            Map(m => m.Tag).Name("tag");

        }
    }
}
