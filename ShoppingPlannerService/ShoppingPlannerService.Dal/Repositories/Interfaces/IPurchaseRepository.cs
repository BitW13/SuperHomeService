using Common.Entity.ShoppingPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Dal.Repositories.Interfaces
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetByShoppingCategoryId(int shoppingCategoryId);

        Task<IEnumerable<Purchase>> GetByTypeOfPurchaseId(int typeOfPurchaseId);
    }
}
