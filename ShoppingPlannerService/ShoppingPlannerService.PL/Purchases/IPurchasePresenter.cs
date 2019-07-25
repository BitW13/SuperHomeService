using Common.Entity.ShoppingPlannerService;
using Common.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlannerService.PL.Purchases
{
    public interface IPurchasePresenter: IPresenter<Purchase>
    {
        Task<IEnumerable<Purchase>> GetByShoppingCategoryIdAsync(int shoppingCategoryId);

        Task<IEnumerable<Purchase>> GetByTypeOfPurchaseIdAsync(int typeOfPurchaseId);
    }
}
