using Common.Entity.ShoppingPlannerService;
using Microsoft.EntityFrameworkCore;
using ShoppingPlannerService.Dal.Context;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Dal.Repositories.Implementations
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ShoppingPlannerServiceContext db;

        public PurchaseRepository(ShoppingPlannerServiceContext db)
        {
            this.db = db;
        }

        public async Task<Purchase> CreateAsync(Purchase item)
        {
            if (item != null)
            {
                db.Purchases.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Purchase> DeleteAsync(int id)
        {
            Purchase item = await db.Purchases.FindAsync(id);

            if (item != null)
            {
                db.Purchases.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await db.Purchases.ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetByShoppingCategoryId(int shoppingCategoryId)
        {
            var purchases = (await GetAllAsync()) as List<Purchase>;

            return purchases.FindAll(purchase => purchase.ShoppingCategoryId == shoppingCategoryId);
        }

        public async Task<IEnumerable<Purchase>> GetByTypeOfPurchaseId(int typeOfPurchaseId)
        {
            var purchases = (await GetAllAsync()) as List<Purchase>;

            return purchases.FindAll(purchase => purchase.TypeOfPurchaseId == typeOfPurchaseId);
        }

        public async Task<Purchase> GetItemByIdAsync(int id)
        {
            return await db.Purchases.FindAsync(id);
        }

        public async Task UpdateAsync(Purchase item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
