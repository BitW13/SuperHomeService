﻿using TaskPlannerService.Bll.Services.Interfaces;

namespace TaskPlannerService.Bll.BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {
        ITaskService Tasks { get; set; }

        ITaskCategoryService TaskCategories { get; set; }

        ISeverityService Severities { get; set; }
    }
}
