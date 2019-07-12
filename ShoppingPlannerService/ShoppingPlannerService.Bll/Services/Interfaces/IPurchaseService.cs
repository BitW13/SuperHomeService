using Common.Entity.ShoppingPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.Bll.Services.Interfaces
{
    public interface IPurchaseService : IService<Purchase>
    {
        Task<IEnumerable<Purchase>> GetByShoppingCategoryIdAsync(int shoppingCategoryId);

        Task<IEnumerable<Purchase>> GetByTypeOfPurchaseIdAsync(int typeOfPurchaseId);
    }
}
