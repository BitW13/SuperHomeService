using CalendarService.Dal.Contexts;
using CalendarService.Dal.Repositories.Interfaces;
using Common.Entity.CalendarService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalendarService.Dal.Repositories.Implementations
{
    public class DateRepository : IDateRepository
    {
        private readonly CalendarServiceContext db;

        public DateRepository(CalendarServiceContext db)
        {
            this.db = db;
        }

        public async Task<Date> CreateAsync(Date item)
        {
            if (item != null)
            {
                db.Dates.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Date> DeleteAsync(int id)
        {
            Date item = await db.Dates.FindAsync(id);

            if (item != null)
            {
                db.Dates.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Date>> GetAllAsync()
        {
            return await db.Dates.ToListAsync();
        }

        public async Task<Date> GetItemByIdAsync(int id)
        {
            return await db.Dates.FindAsync(id);
        }

        public async Task UpdateAsync(Date item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
