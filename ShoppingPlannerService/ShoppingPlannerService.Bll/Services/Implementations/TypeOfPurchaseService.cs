using Common.Entity.ShoppingPlannerService;
using Common.Helpers;
using ShoppingPlannerService.Bll.Services.Interfaces;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Bll.Services.Implementations
{
    public class TypeOfPurchaseService : ITypeOfPurchaseService
    {
        private readonly ITypeOfPurchaseRepository db;

        public TypeOfPurchaseService(ITypeOfPurchaseRepository db)
        {
            this.db = db;
        }

        public async Task<TypeOfPurchase> CreateAsync(TypeOfPurchase item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<TypeOfPurchase> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<TypeOfPurchase>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<TypeOfPurchase> GetItemByIdAsync(int id)
        {
            TypeOfPurchase typeOfPurchase = await db.GetItemByIdAsync(id);

            if (typeOfPurchase == null)
            {
                return Constants.DefaultTypeOfPurchase.TypeOfPurchase;
            }

            return typeOfPurchase;
        }

        public async Task UpdateAsync(TypeOfPurchase item)
        {
            await db.UpdateAsync(item);
        }
    }
}
