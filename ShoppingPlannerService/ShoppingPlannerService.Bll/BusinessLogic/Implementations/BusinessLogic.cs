using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using ShoppingPlannerService.Bll.Services.Interfaces;

namespace ShoppingPlannerService.Bll.BusinessLogic.Implementations
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IPurchaseService purchases, ITypeOfPurchaseService typeOfPurchases)
        {
            Purchases = purchases;
            TypeOfPurchases = typeOfPurchases;
        }

        public IPurchaseService Purchases { get; set; }

        public ITypeOfPurchaseService TypeOfPurchases { get; set; }
    }
}
