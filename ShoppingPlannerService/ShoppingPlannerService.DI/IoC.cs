using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingPlannerService.Bll.BusinessLogic.Implementations;
using ShoppingPlannerService.Bll.BusinessLogic.Interfaces;
using ShoppingPlannerService.Bll.Services.Implementations;
using ShoppingPlannerService.Bll.Services.Interfaces;
using ShoppingPlannerService.Dal.Context;
using ShoppingPlannerService.Dal.DataAccess.Implementations;
using ShoppingPlannerService.Dal.DataAccess.Interfaces;
using ShoppingPlannerService.Dal.Repositories.Implementations;
using ShoppingPlannerService.Dal.Repositories.Interfaces;
using ShoppingPlannerService.PL;
using ShoppingPlannerService.PL.Purchases;
using ShoppingPlannerService.PL.PurchaseTypes;
using ShoppingPlannerService.PL.ShoppingCards;
using ShoppingPlannerService.PL.ShoppingCategories;

namespace ShoppingPlannerService.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShoppingPlannerServiceContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IShoppingCategoryRepository, ShoppingCategoryRepository>();
            services.AddTransient<ITypeOfPurchaseRepository, TypeOfPurchaseRepository>();

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<IShoppingCategoryService, ShoppingCategoryService>();
            services.AddTransient<ITypeOfPurchaseService, TypeOfPurchaseService>();

            services.AddTransient<IPresenterLayer, PresenterLayer>();
            services.AddTransient<IPurchasePresenter, PurchasePresenter>();
            services.AddTransient<IShoppingCategoryPresenter, ShoppingCategoryPresenter>();
            services.AddTransient<ITypeOfPurchasePresenter, TypeOfPurchasePresenter>();
            services.AddTransient<IShoppingCardPresenter, ShoppingCardPresenter>();
        }
    }
}
