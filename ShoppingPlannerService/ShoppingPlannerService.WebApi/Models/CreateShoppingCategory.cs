using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class CreateShoppingCategory
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public bool IsOn { get; set; }
    }
}
