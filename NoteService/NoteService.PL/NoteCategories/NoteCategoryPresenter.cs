using Common.Entity.NoteService;
using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.Bll.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.NoteCategories
{
    public class NoteCategoryPresenter : INoteCategoryPresenter
    {
        private readonly INoteCategoryService db;

        public NoteCategoryPresenter(INoteCategoryService db)
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
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(NoteCategory item)
        {
            await db.UpdateAsync(item);
        }
    }
}
