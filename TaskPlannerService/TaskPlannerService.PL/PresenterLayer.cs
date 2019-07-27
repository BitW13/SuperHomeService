using TaskPlannerService.PL.Severities;
using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;
using TaskPlannerService.PL.Tasks;

namespace TaskPlannerService.PL
{
    public class PresenterLayer : IPresenterLayer
    {
        public PresenterLayer(ITaskCardPresenter cards, ITaskPresenter tasks, ITaskCategoryPresenter taskCategories, ISeverityPresenter severities)
        {
            Cards = cards;
            Tasks = tasks;
            TaskCategories = taskCategories;
            Severities = severities;
        }

        public ITaskCardPresenter Cards { get; set; }
        public ITaskPresenter Tasks { get; set; }
        public ITaskCategoryPresenter TaskCategories { get; set; }
        public ISeverityPresenter Severities { get; set; }
    }
}
