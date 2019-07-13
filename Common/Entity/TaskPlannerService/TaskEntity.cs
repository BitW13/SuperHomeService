using System.ComponentModel.DataAnnotations;

namespace Common.Entity.TaskPlannerService
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int TaskCategoryId { get; set; }

        [Required]
        public int PlannerDateId { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
