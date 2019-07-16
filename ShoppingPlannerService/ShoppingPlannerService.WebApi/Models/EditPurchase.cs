using System.ComponentModel.DataAnnotations;

namespace ShoppingPlannerService.WebApi.Models
{
    public class EditPurchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int TypeOfPurchaseId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public float PriceOfOneUnit { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public int ShoppingCategoryId { get; set; }

        public int PlannerDateId { get; set; }
    }
}
