using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InterviewTestProject
{
    public class ApplicationContext: DbContext
    {
        public DbSet<EventModel> Events { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
