using TaskPlannerService.Dal.DataAccess.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.DataAccess.Implementations
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ITaskRepository tasks, ITaskCategoryRepository taskCategories)
        {
            Tasks = tasks;
            TaskCategories = taskCategories;
        }

        public ITaskRepository Tasks { get; set; }
        public ITaskCategoryRepository TaskCategories { get; set; }
    }
}
