using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class EditPurchase
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeOfPurchaseId { get; set; }

        public float Amount { get; set; }

        public float PriceOfOneUnit { get; set; }

        public float TotalPrice { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public bool ShoppingCategoryId { get; set; }

        public int PlannerDate { get; set; }
    }
}
