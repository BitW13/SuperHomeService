using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskPlannerService.PL.Tasks
{
    public interface ITaskPresenter : IPresenter<TaskEntity, TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId);

        Task<IEnumerable<TaskEntity>> GetBySeverityIdAsync(int severityId);
    }
}
