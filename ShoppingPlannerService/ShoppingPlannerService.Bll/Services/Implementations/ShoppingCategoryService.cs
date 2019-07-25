using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.Bll.Services.Interfaces;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Bll.Services.Implementations
{
    public class ShoppingCategoryService : IShoppingCategoryService
    {
        private readonly IShoppingCategoryRepository db;

        public ShoppingCategoryService(IShoppingCategoryRepository db)
        {
            this.db = db;
        }
        public async Task<ShoppingCategory> CreateAsync(ShoppingCategory item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<ShoppingCategory> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShoppingCategory>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<ShoppingCategory> GetItemByIdAsync(int id)
        {
            ShoppingCategory shoppingCategory = await db.GetItemByIdAsync(id);

            if (shoppingCategory == null)
            {
                return ShoppingPlannerDefaultValues.DefaultShoppingCategory.ShoppingCategory;
            }

            return shoppingCategory;
        }

        public async Task UpdateAsync(ShoppingCategory item)
        {
            await db.UpdateAsync(item);
        }
    }
}
