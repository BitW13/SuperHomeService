using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class SeverityRepository : ISeverityRepository
    {
        private readonly TaskPlannerServiceContext db;

        public SeverityRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }

        public async Task<Severity> CreateAsync(Severity item)
        {
            if (item != null)
            {
                db.Severities.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Severity> DeleteAsync(int id)
        {
            Severity item = await db.Severities.FindAsync(id);

            if (item != null)
            {
                db.Severities.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Severity>> GetAllAsync()
        {
            return await db.Severities.ToListAsync();
        }

        public async Task<Severity> GetItemByIdAsync(int id)
        {
            return await db.Severities.FindAsync(id);
        }

        public async Task UpdateAsync(Severity item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
