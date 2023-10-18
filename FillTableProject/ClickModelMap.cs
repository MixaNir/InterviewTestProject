using CsvHelper.Configuration;


namespace FillTableProject
{
    public sealed class ClickModelMap : ClassMap<ClickModel>
    {

        public ClickModelMap()
        {
            Map(m => m.UId).Name("uid");
            Map(m => m.Tag).Name("tag");
        }
    }
}
