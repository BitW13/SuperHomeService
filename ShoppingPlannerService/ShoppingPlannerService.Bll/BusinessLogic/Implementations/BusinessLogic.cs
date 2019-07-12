using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using ShoppingPlannerService.Bll.Services.Interfaces;

namespace ShoppingPlannerService.Bll.BusinessLogic.Implementations
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IPurchaseService purchases, ITypeOfPurchaseService typeOfPurchases, IShoppingCategoryService shoppingCategories)
        {
            Purchases = purchases;
            TypeOfPurchases = typeOfPurchases;
            ShoppingCategories = shoppingCategories;
        }

        public IPurchaseService Purchases { get; set; }

        public ITypeOfPurchaseService TypeOfPurchases { get; set; }

        public IShoppingCategoryService ShoppingCategories { get; set; }
    }
}
