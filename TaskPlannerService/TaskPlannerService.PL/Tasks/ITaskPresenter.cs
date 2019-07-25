using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskPlannerService.PL.Tasks
{
    public interface ITaskPresenter : IPresenter<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByTaskCategoryIdAsync(int taskCategoryId);
    }
}
