using Microsoft.EntityFrameworkCore;

namespace FillTableProject
{
    public class ApplicationContext: DbContext
    {
        public DbSet<EventModel> Events { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=InterviewProject; Trusted_Connection=true; TrustServerCertificate=True");
        }
    }
}
