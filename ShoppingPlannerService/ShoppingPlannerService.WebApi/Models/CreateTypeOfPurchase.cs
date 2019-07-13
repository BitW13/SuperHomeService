using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class CreateTypeOfPurchase
    {
        [Required]
        public string Name { get; set; }
    }
}
