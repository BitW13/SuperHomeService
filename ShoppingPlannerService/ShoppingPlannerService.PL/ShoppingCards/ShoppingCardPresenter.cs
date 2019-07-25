using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.PL.ShoppingCards
{
    public class ShoppingCardPresenter : IShoppingCardPresenter
    {
        private readonly IBusinessLogic db;

        public ShoppingCardPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public async Task<ShoppingCard> CreateAsync(Purchase item)
        {
            Purchase purchase = await db.Purchases.CreateAsync(item);

            return await GetItemByIdAsync(purchase.Id);
        }

        public async Task<IEnumerable<ShoppingCard>> GetAllAsync()
        {
            IEnumerable<Purchase> purchases = await db.Purchases.GetAllAsync();

            List<ShoppingCard> cards = new List<ShoppingCard>();

            foreach (var purchase in purchases)
            {
                ShoppingCategory category = await db.ShoppingCategories.GetItemByIdAsync(purchase.ShoppingCategoryId);

                TypeOfPurchase type = await db.TypeOfPurchases.GetItemByIdAsync(purchase.TypeOfPurchaseId);

                cards.Add(new ShoppingCard { Purchase = purchase, ShoppingCategory = category, TypeOfPurchase = type });
            }

            return cards;
        }

        public async Task<ShoppingCard> GetItemByIdAsync(int id)
        {
            Purchase purchase = await db.Purchases.GetItemByIdAsync(id);

            if (purchase == null)
            {
                return null;
            }

            ShoppingCategory category = await db.ShoppingCategories.GetItemByIdAsync(purchase.ShoppingCategoryId);

            TypeOfPurchase type = await db.TypeOfPurchases.GetItemByIdAsync(purchase.TypeOfPurchaseId);

            ShoppingCard card = new ShoppingCard
            {
                Purchase = purchase,
                ShoppingCategory = category,
                TypeOfPurchase = type
            };

            return card;
        }

        public async Task<ShoppingCard> UpdateAsync(Purchase item)
        {
            await db.Purchases.UpdateAsync(item);

            return await GetItemByIdAsync(item.Id);
        }
    }
}
