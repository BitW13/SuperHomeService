using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.Bll.Services.Interfaces;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Bll.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository db;

        public PurchaseService(IPurchaseRepository db)
        {
            this.db = db;
        }

        public async Task<Purchase> CreateAsync(Purchase item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<Purchase> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<Purchase>> GetByShoppingCategoryIdAsync(int shoppingCategoryId)
        {
            return await db.GetByShoppingCategoryId(shoppingCategoryId);
        }

        public async Task<IEnumerable<Purchase>> GetByTypeOfPurchaseIdAsync(int typeOfPurchaseId)
        {
            return await db.GetByTypeOfPurchaseId(typeOfPurchaseId);
        }

        public async Task<Purchase> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Purchase item)
        {
            await db.UpdateAsync(item);
        }
    }
}
