using FillTableProject;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

void AddXTable()
{
    try
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = false,
                HeaderValidated = null,
                MissingFieldFound = null,
            };
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "\\interview.X.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<EventModelMap>();
                var records = csv.GetRecords<EventModel>();
                int i = 0;
                foreach (var record in records)
                {
                    try
                    {
                        db.Events.Add(record);
                    }
                    catch
                    {
                        Console.WriteLine("Error" + record.UID.ToString());
                        db.Events.Remove(record);
                    }
                    if (i % 100000 == 0)
                        Console.WriteLine(i.ToString());
                    ++i;
                };
                db.SaveChanges();



            }
        }
    } 
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

void AddYTable()
{
    try
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = false,
                HeaderValidated = null,
                MissingFieldFound = null,
            };
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "\\interview.Y.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<ClickModelMap>();
                var records = csv.GetRecords<ClickModel>();
                int i = 0;
                foreach (var record in records)
                {
                    try
                    {
                        var temItem = db.Events.Where(item => item.UID.Equals(record.UId)).FirstOrDefault();
                        if (temItem is not null)
                        {
                            temItem.Tag = record.Tag;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error" + record.UId.ToString());
                    }
                    if (i % 1000 == 0)
                        Console.WriteLine(i.ToString());
                    ++i;
                };
                db.SaveChanges();

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}


AddXTable();
AddYTable();