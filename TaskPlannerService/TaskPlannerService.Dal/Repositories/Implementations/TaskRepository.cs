using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskPlannerServiceContext db;

        public TaskRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }
        public async Task<TaskEntity> CreateAsync(TaskEntity item)
        {
            if (item != null)
            {
                db.Tasks.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<TaskEntity> DeleteAsync(int id)
        {
            TaskEntity item = await db.Tasks.FindAsync(id);

            if (item != null)
            {
                db.Tasks.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await db.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetBySeverityIdAsync(int severityId)
        {
            var notes = (await GetAllAsync()) as List<TaskEntity>;

            return notes.FindAll(note => note.SeverityId == severityId);
        }

        public async Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId)
        {
            var notes = (await GetAllAsync()) as List<TaskEntity>;

            return notes.FindAll(note => note.TaskCategoryId == taskCategoryId);
        }

        public async Task<TaskEntity> GetItemByIdAsync(int id)
        {
            return await db.Tasks.FindAsync(id);
        }

        public async Task UpdateAsync(TaskEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
