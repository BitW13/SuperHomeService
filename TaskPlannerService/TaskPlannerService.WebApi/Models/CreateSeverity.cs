using System.ComponentModel.DataAnnotations;

namespace TaskPlannerService.WebApi.Models
{
    public class CreateSeverity
    {
        [Required]
        public string Name { get; set; }
    }
}
