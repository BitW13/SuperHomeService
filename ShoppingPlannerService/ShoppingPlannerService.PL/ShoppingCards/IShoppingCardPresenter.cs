using Common.Entity.ShoppingPlannerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingPlannerService.PL.ShoppingCards
{
    public interface IShoppingCardPresenter
    {
        Task<IEnumerable<ShoppingCard>> GetAllAsync();

        Task<ShoppingCard> GetItemByIdAsync(int id);

        Task<ShoppingCard> CreateAsync(Purchase item);

        Task<ShoppingCard> UpdateAsync(Purchase item);
    }
}
