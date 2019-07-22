using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteService.Bll.BusinessLogic.Implementations;
using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.Bll.Services.Implementations;
using NoteService.Bll.Services.Interfaces;
using NoteService.Dal.DataAccess.Implementations;
using NoteService.Dal.DataAccess.Interfaces;
using NoteService.PL;
using NoteService.PL.NoteCards;
using NoteService.PL.NoteCategories;
using NoteService.PL.Notes;
using NotesService.Dal.Contexts;
using NotesService.Dal.Repositories.Implementations;
using NotesService.Dal.Repositories.Interfaces;

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


            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<INoteEntityService, NoteEntityService>();
            services.AddTransient<INoteCategoryService, NoteCategoryService>();
            services.AddTransient<INoteSortService, SortService>();

            services.AddTransient<IPresenterLayer, PresenterLayer>();
            services.AddTransient<INotePresenter, NotePresenter>();
            services.AddTransient<INoteCategoryPresenter, NoteCategoryPresenter>();
            services.AddTransient<INoteCardPresenter, NoteCardPresenter>();
        }
    }
}
