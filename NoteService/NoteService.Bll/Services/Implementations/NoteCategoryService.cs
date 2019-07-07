using Common.Entity.NoteService;
using NoteService.Bll.Helpers;
using NoteService.Bll.Services.Interfaces;
using NotesService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.Bll.Services.Implementations
{
    public class NoteCategoryService : INoteCategoryService
    {
        private readonly INoteCategoryRepository db;

        public NoteCategoryService(INoteCategoryRepository db)
        {
            this.db = db;
        }

        public async Task<NoteCategory> CreateAsync(NoteCategory item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<NoteCategory> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<NoteCategory>> GetAllAsync()
        {
            return await db.GetAllAsync();

        }

        public async Task<NoteCategory> GetItemByIdAsync(int id)
        {
            NoteCategory noteCategory = await db.GetItemByIdAsync(id);
            if(noteCategory == null)
            {
                noteCategory = SetDefaultCategoryIfNull();
            }
            return noteCategory;
        }

        public async Task UpdateAsync(NoteCategory item)
        {
            await db.UpdateAsync(item);
        }

        private NoteCategory SetDefaultCategoryIfNull()
        {
            return new NoteCategory
            {
                Color = Constants.DefaultColors.Color,
                Name = Constants.DefaultNoteCategoryNames.Name,
                IsOn = Constants.DefaultIsOn.IsOn
            };
        }
    }
}
