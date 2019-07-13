using Common.Entity.TaskPlannerService;
using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class TaskCard
    {
        [Required]
        public TaskEntity Task { get; set; }

        public TaskCategory TaskCategory { get; set; }
    }
}
