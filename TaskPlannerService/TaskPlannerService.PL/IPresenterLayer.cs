using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;
using TaskPlannerService.PL.Tasks;

namespace TaskPlannerService.PL
{
    public interface IPresenterLayer
    {
        ITaskCardPresenter Cards { get; set; }

        ITaskPresenter Tasks { get; set; }

        ITaskCategoryPresenter TaskCategories { get; set; }
    }
}
