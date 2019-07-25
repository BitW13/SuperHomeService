using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;
using TaskPlannerService.PL.Tasks;

namespace TaskPlannerService.PL
{
    public class PresenterLayer : IPresenterLayer
    {
        public PresenterLayer(ITaskCardPresenter cards, ITaskPresenter tasks, ITaskCategoryPresenter taskCategories)
        {
            Cards = cards;
            Tasks = tasks;
            TaskCategories = taskCategories;
        }

        public ITaskCardPresenter Cards { get; set; }
        public ITaskPresenter Tasks { get; set; }
        public ITaskCategoryPresenter TaskCategories { get; set; }
    }
}
