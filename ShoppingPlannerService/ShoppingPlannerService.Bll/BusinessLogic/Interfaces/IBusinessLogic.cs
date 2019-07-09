using ShoppingPlannerService.Bll.Services.Interfaces;

namespace ShoppingPlannerService.Bll.BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {
        IPurchaseService Purchases { get; set; }

        ITypeOfPurchaseService TypeOfPurchases { get; set; }
    }
}
