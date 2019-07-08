using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly ITaskCategoryRepository db;

        public TaskCategoryService(ITaskCategoryRepository db)
        {
            this.db = db;
        }

        public async Task<TaskCategory> CreateAsync(TaskCategory item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<TaskCategory> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskCategory>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<TaskCategory> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(TaskCategory item)
        {
            await db.UpdateAsync(item);
        }
    }
}
