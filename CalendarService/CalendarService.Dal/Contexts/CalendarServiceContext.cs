using Common.Entity.CalendarService;
using Microsoft.EntityFrameworkCore;

namespace CalendarService.Dal.Contexts
{
    public class CalendarServiceContext : DbContext
    {
        public CalendarServiceContext(DbContextOptions<CalendarServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Date> Dates { get; set; }
    }
}
