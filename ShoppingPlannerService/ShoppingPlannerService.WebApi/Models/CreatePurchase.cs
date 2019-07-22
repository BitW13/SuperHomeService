using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class CreatePurchase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeOfPurchaseId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public float PriceOfOneUnit { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        public bool IsDone { get; set; }

        public bool ShoppingCategoryId { get; set; }

        public int PlannerDate { get; set; }
    }
}
