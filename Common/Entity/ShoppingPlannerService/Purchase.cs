using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ShoppingPlannerService
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
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
        public bool ShoppingCategoryId { get; set; }

        [Required]
        public int PlannerDate { get; set; }
    }
}
