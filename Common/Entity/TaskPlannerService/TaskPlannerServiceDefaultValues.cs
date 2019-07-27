namespace Common.Entity.TaskPlannerService
{
    public static class TaskPlannerServiceDefaultValues
    {
        public static class DefaultTaskCategories
        {
            public static TaskCategory TaskCategory
            {
                get
                {
                    return new TaskCategory
                    {
                        Id = 0,
                        Name = "Категория",
                        Color = "000",
                        ImagePath = "https://st3.depositphotos.com/2903611/13027/i/950/depositphotos_130272574-stock-photo-phone-on-notepad-pen-coffee.jpg",
                        IsOn = true
                    };
                }
            }

            public static TaskCategory VerificationAndCorrectionDataForCreating(TaskCategory item)
            {
                if (item.Id != 0) { item.Id = TaskCategory.Id; }

                if (string.IsNullOrEmpty(item.Name)) { item.Name = TaskCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = TaskCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.ImagePath = TaskCategory.ImagePath; }

                if (item.IsOn == false) { item.IsOn = TaskCategory.IsOn; }

                return item;
            }

            public static TaskCategory VerificationAndCorrectionDataForEdit(TaskCategory item)
            {
                if (string.IsNullOrEmpty(item.Name)) { item.Name = TaskCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = TaskCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.ImagePath = TaskCategory.ImagePath; }

                return item;
            }
        }

        public static class DefaultTask
        {
            public static TaskEntity Task
            {
                get
                {
                    return new TaskEntity
                    {
                        Id = 0,
                        Name = "Задача",
                        Description = "",
                        TaskCategoryId = 0,
                        PlannerDateId = 0,
                        IsDone = false
                    };
                }
            }

            public static TaskEntity VerificationAndCorrectionDataForCreating(TaskEntity item)
            {
                if (item.Id != 0) { item.Id = Task.Id; }

                if (item.PlannerDateId < 0) { item.PlannerDateId = Task.PlannerDateId; }

                if (item.TaskCategoryId < 0) { item.TaskCategoryId = Task.TaskCategoryId; }

                return item;
            }

            public static TaskEntity VerificationAndCorrectionDataForEdit(TaskEntity item)
            {
                if (item.TaskCategoryId < 0) { item.TaskCategoryId = Task.TaskCategoryId; }

                if (item.PlannerDateId < 0) { item.PlannerDateId = Task.PlannerDateId; }

                return item;
            }
        }
    }
}
