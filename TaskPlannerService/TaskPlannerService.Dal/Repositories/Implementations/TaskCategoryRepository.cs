using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly TaskPlannerServiceContext db;

        public TaskCategoryRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }

        public async Task<TaskCategory> CreateAsync(TaskCategory item)
        {
            if (item != null)
            {
                db.TaskCategories.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<TaskCategory> DeleteAsync(int id)
        {
            TaskCategory item = await db.TaskCategories.FindAsync(id);

            if (item != null)
            {
                db.TaskCategories.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<TaskCategory>> GetAllAsync()
        {
            return await db.TaskCategories.ToListAsync();
        }

        public async Task<TaskCategory> GetItemByIdAsync(int id)
        {
            return await db.TaskCategories.FindAsync(id);
        }

        public async Task UpdateAsync(TaskCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
