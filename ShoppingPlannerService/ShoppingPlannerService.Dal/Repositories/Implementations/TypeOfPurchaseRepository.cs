using Common.Entity.ShoppingPlannerService;
using Microsoft.EntityFrameworkCore;
using ShoppingPlannerService.Dal.Context;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Dal.Repositories.Implementations
{
    public class TypeOfPurchaseRepository : ITypeOfPurchaseRepository
    {
        private readonly ShoppingPlannerServiceContext db;

        public TypeOfPurchaseRepository(ShoppingPlannerServiceContext db)
        {
            this.db = db;
        }

        public async Task<TypeOfPurchase> CreateAsync(TypeOfPurchase item)
        {
            if (item != null)
            {
                db.TypeOfPurchases.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<TypeOfPurchase> DeleteAsync(int id)
        {
            TypeOfPurchase item = await db.TypeOfPurchases.FindAsync(id);

            if (item != null)
            {
                db.TypeOfPurchases.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<TypeOfPurchase>> GetAllAsync()
        {
            return await db.TypeOfPurchases.ToListAsync();
        }

        public async Task<TypeOfPurchase> GetItemByIdAsync(int id)
        {
            return await db.TypeOfPurchases.FindAsync(id);
        }

        public async Task UpdateAsync(TypeOfPurchase item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
