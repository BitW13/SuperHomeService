using Authentication.Dal.Contexts;
using Authentication.Dal.DataAccess;
using Authentication.Dal.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
