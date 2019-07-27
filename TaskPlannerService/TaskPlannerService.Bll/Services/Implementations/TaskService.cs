using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository db;

        public TaskService(ITaskRepository db)
        {
            this.db = db;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<TaskEntity> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetBySeverityIdAsync(int severityId)
        {
            return await db.GetBySeverityIdAsync(severityId);
        }

        public async Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId)
        {
            return await db.GetByTaskCategoryIdAsync(taskCategoryId);
        }

        public async Task<TaskEntity> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(TaskEntity item)
        {
            await db.UpdateAsync(item);
        }
    }
}
