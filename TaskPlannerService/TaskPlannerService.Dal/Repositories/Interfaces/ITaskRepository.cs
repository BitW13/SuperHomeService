using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskPlannerService.Dal.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId);
    }
}
