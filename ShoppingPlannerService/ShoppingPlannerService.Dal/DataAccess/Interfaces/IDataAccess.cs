using ShoppingPlannerService.Dal.Repositories.Interfaces;

namespace ShoppingPlannerService.Dal.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        IPurchaseRepository Purchases { get; set; }

        ITypeOfPurchaseRepository TypeOfPurchases { get; set; }
    }
}
