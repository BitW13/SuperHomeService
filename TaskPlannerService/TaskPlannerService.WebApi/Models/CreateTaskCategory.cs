using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class CreateTaskCategory
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public bool IsOn { get; set; }
    }
}
