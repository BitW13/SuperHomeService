using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteService.Dal.DataAccess.Implementations;
using NoteService.Dal.DataAccess.Interfaces;
using NotesService.Dal.Contexts;
using NotesService.Dal.Repositories.Implementations;
using NotesService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<INoteCategoryRepository, NoteCategoryRepository>();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<NoteServiceContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
