using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ShoppingPlannerService
{
    public class TypeOfPurchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
