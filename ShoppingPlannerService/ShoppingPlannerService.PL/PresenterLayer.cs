using ShoppingPlannerService.PL.Purchases;
using ShoppingPlannerService.PL.PurchaseTypes;
using ShoppingPlannerService.PL.ShoppingCards;
using ShoppingPlannerService.PL.ShoppingCategories;

namespace ShoppingPlannerService.PL
{
    public class PresenterLayer : IPresenterLayer
    {
        public PresenterLayer(IPurchasePresenter purchases, IShoppingCategoryPresenter shoppingCategories, ITypeOfPurchasePresenter typeOfPurchases,
            IShoppingCardPresenter cards)
        {
            Purchases = purchases;
            ShoppingCategories = shoppingCategories;
            TypeOfPurchases = typeOfPurchases;
            Cards = cards;
        }
        public IPurchasePresenter Purchases { get; set; }

        public IShoppingCategoryPresenter ShoppingCategories { get; set; }

        public ITypeOfPurchasePresenter TypeOfPurchases { get; set; }

        public IShoppingCardPresenter Cards { get; set; }
    }
}
