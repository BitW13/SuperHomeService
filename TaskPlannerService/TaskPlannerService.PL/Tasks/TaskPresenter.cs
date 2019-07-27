using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.Services.Interfaces;

namespace TaskPlannerService.PL.Tasks
{
    public class TaskPresenter : ITaskPresenter
    {
        private readonly ITaskService db;

        public TaskPresenter(ITaskService db)
        {
            this.db = db;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity item)
        {
            return await db.CreateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            TaskEntity task = await db.GetItemByIdAsync(id);

            if (task == null)
            {
                return;
            }

            await db.DeleteAsync(task.Id);
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

        public async Task<TaskEntity> UpdateAsync(TaskEntity item)
        {
            await db.UpdateAsync(item);

            return item;
        }
    }
}
