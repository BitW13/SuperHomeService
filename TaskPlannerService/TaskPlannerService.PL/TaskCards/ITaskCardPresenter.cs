using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskPlannerService.PL.TaskCards
{
    public interface ITaskCardPresenter
    {
        Task<IEnumerable<TaskCard>> GetAllAsync();

        Task<TaskCard> GetItemByIdAsync(int id);

        Task<TaskCard> CreateAsync(TaskEntity item);

        Task<TaskCard> UpdateAsync(TaskEntity item);
    }
}
