using Common.Entity.ShoppingPlannerService;
using Microsoft.EntityFrameworkCore;
using ShoppingPlannerService.Dal.Context;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Dal.Repositories.Implementations
{
    public class ShoppingCategoryRepository : IShoppingCategoryRepository
    {
        private readonly ShoppingPlannerServiceContext db;

        public ShoppingCategoryRepository(ShoppingPlannerServiceContext db)
        {
            this.db = db;
        }
        public async Task<ShoppingCategory> CreateAsync(ShoppingCategory item)
        {
            if (item != null)
            {
                db.ShoppingCategories.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<ShoppingCategory> DeleteAsync(int id)
        {
            ShoppingCategory item = await db.ShoppingCategories.FindAsync(id);

            if (item != null)
            {
                db.ShoppingCategories.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<ShoppingCategory>> GetAllAsync()
        {
            return await db.ShoppingCategories.ToListAsync();
        }

        public async Task<ShoppingCategory> GetItemByIdAsync(int id)
        {
            return await db.ShoppingCategories.FindAsync(id);
        }

        public async Task UpdateAsync(ShoppingCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
