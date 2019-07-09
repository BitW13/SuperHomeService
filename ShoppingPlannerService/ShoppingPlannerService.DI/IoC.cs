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
            services.AddTransient<ITypeOfPurchaseRepository, TypeOfPurchaseRepository>();

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ITypeOfPurchaseService, TypeOfPurchaseService>();
        }
    }
}
