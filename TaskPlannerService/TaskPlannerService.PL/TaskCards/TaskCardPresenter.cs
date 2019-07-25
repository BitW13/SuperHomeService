using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;

namespace TaskPlannerService.PL.TaskCards
{
    public class TaskCardPresenter : ITaskCardPresenter
    {
        private readonly IBusinessLogic db;

        public TaskCardPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public async Task<TaskCard> CreateAsync(TaskEntity item)
        {
            TaskEntity task = await db.Tasks.CreateAsync(item);

            return await GetItemByIdAsync(task.Id);
        }

        public async Task<IEnumerable<TaskCard>> GetAllAsync()
        {
            IEnumerable<TaskEntity> tasks = await db.Tasks.GetAllAsync();

            List<TaskCard> cards = new List<TaskCard>();

            foreach (var task in tasks)
            {
                TaskCategory category = await db.TaskCategories.GetItemByIdAsync(task.TaskCategoryId);

                cards.Add(new TaskCard { Task = task, TaskCategory = category });
            }

            return cards;
        }

        public async Task<TaskCard> GetItemByIdAsync(int id)
        {
            TaskEntity task = await db.Tasks.GetItemByIdAsync(id);

            if (task == null)
            {
                return null;
            }

            TaskCategory category = await db.TaskCategories.GetItemByIdAsync(task.TaskCategoryId);

            TaskCard card = new TaskCard
            {
                Task = task,
                TaskCategory = category
            };

            return card;
        }

        public async Task<TaskCard> UpdateAsync(TaskEntity item)
        {
            await db.Tasks.UpdateAsync(item);

            return await GetItemByIdAsync(item.Id);
        }
    }
}
