using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskPlannerService.Bll.BusinessLogic.Implementations;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;
using TaskPlannerService.Bll.Services.Implementations;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.DataAccess.Implementations;
using TaskPlannerService.Dal.DataAccess.Interfaces;
using TaskPlannerService.Dal.Repositories.Implementations;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TaskPlannerServiceContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskCategoryService, TaskCategoryService>();
        }
    }
}
