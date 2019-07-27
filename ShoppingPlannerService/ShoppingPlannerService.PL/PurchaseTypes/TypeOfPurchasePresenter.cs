using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.Bll.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.PL.PurchaseTypes
{
    public class TypeOfPurchasePresenter : ITypeOfPurchasePresenter
    {
        private readonly ITypeOfPurchaseService db;

        public TypeOfPurchasePresenter(ITypeOfPurchaseService db)
        {
            this.db = db;
        }

        public async Task<TypeOfPurchase> CreateAsync(TypeOfPurchase item)
        {
            return await db.CreateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<TypeOfPurchase>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<TypeOfPurchase> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task<TypeOfPurchase> UpdateAsync(TypeOfPurchase item)
        {
            await db.UpdateAsync(item);

            return item;
        }
    }
}
