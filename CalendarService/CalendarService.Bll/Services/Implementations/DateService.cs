using CalendarService.Bll.Services.Interfaces;
using CalendarService.Dal.Repositories.Interfaces;
using Common.Entity.CalendarService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalendarService.Bll.Services.Implementations
{
    public class DateService : IDateService
    {
        private readonly IDateRepository db;

        public DateService(IDateRepository db)
        {
            this.db = db;
        }

        public async Task<Date> CreateAsync(Date item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<Date> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Date>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Date> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Date item)
        {
            await db.UpdateAsync(item);
        }
    }
}
