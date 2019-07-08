using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class EditTask
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public int TaskCategoryId { get; set; }

        [Required]
        public int DateId { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
