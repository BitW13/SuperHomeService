using ShoppingPlannerService.Dal.DataAccess.Interfaces;
using ShoppingPlannerService.Dal.Repositories.Interfaces;

namespace ShoppingPlannerService.Dal.DataAccess.Implementations
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IPurchaseRepository purchases, ITypeOfPurchaseRepository typeOfPurchases)
        {
            Purchases = purchases;
            TypeOfPurchases = typeOfPurchases;
        }

        public IPurchaseRepository Purchases { get; set; }

        public ITypeOfPurchaseRepository TypeOfPurchases { get; set; }
    }
}
