using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskPlannerService.Bll.Services.Interfaces
{
    public interface ITaskService : IService<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId);
    }
}
