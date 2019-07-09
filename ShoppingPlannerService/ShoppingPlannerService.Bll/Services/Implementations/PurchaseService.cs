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

        public async Task<Purchase> GetItemByIdAsync(int id)
        {
            Purchase purchase = await db.GetItemByIdAsync(id);

            if (purchase == null)
            {
                
            }

            return purchase;
        }

        public async Task UpdateAsync(Purchase item)
        {
            await db.UpdateAsync(item);
        }
    }
}
