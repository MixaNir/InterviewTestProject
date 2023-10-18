using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestProject
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
