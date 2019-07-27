using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.Bll.Services.Interfaces;

namespace ShoppingPlannerService.PL.ShoppingCategories
{
    public class ShoppingCategoryPresenter : IShoppingCategoryPresenter
    {
        private readonly IShoppingCategoryService db;

        public ShoppingCategoryPresenter(IShoppingCategoryService db)
        {
            this.db = db;
        }

        public async Task<ShoppingCategory> CreateAsync(ShoppingCategory item)
        {
            return await db.CreateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShoppingCategory>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<ShoppingCategory> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task<ShoppingCategory> UpdateAsync(ShoppingCategory item)
        {
            await db.UpdateAsync(item);

            return item;
        }
    }
}
