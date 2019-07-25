using ShoppingPlannerService.PL.Purchases;
using ShoppingPlannerService.PL.PurchaseTypes;
using ShoppingPlannerService.PL.ShoppingCards;
using ShoppingPlannerService.PL.ShoppingCategories;

namespace ShoppingPlannerService.PL
{
    public interface IPresenterLayer
    {
        IPurchasePresenter Purchases { get; set; }

        IShoppingCategoryPresenter ShoppingCategories { get; set; }

        ITypeOfPurchasePresenter TypeOfPurchases { get; set; }

        IShoppingCardPresenter Cards { get; set; }
    }
}
