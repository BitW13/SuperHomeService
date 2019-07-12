using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class EditTypeOfPurchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
