using Common.Entity.ShoppingPlannerService;

namespace ShoppingPlannerService.Bll.Helpers
{
    public static class Constants
    {
        public static class DefaultTypeOfPurchase
        {
            public static readonly TypeOfPurchase TypeOfPurchase = new TypeOfPurchase
            {
                Id = 0,
                Name = "ед"
            };
        }

        public static class DefaultShoppingCategory
        {
            public static readonly ShoppingCategory ShoppingCategory = new ShoppingCategory
            {
                Id = 0,
                Name = "Новая категория",
                Color = "000",
                ImagePath = "https://st3.depositphotos.com/13821126/18366/v/1600/depositphotos_183663702-stock-illustration-sale-bags-packages-in-the.jpg",
                IsOn = true
            };
        }
    }
}
