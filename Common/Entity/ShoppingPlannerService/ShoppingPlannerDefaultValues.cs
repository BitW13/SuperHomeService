namespace Common.Entity.ShoppingPlannerService
{
    public static class ShoppingPlannerDefaultValues
    {
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

            public static ShoppingCategory VerificationAndCorrectioDataForCreating(ShoppingCategory item)
            {
                if (item.Id != 0) { item.Id = ShoppingCategory.Id; }

                if (string.IsNullOrEmpty(item.Name)) { item.Name = ShoppingCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = ShoppingCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.Color = ShoppingCategory.ImagePath; }

                if (item.IsOn == false) { item.IsOn = ShoppingCategory.IsOn; }

                return item;
            }

            public static ShoppingCategory VerificationAndCorrectioDataForEdit(ShoppingCategory item)
            {
                if (string.IsNullOrEmpty(item.Name)) { item.Name = ShoppingCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = ShoppingCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.Color = ShoppingCategory.ImagePath; }

                return item;
            }
        }
    }
}
