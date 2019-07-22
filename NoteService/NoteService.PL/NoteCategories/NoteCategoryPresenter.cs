using Common.Entity.NoteService;
using NoteService.Bll.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.NoteCategories
{
    public class NoteCategoryPresenter : INoteCategoryPresenter
    {
        private readonly IBusinessLogic db;

        public NoteCategoryPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public async Task<NoteCategory> CreateAsync(NoteCategory item)
        {
            return await db.NoteCategories.CreateAsync(item);
        }

        public async Task<NoteCategory> DeleteAsync(int id)
        {
            return await db.NoteCategories.DeleteAsync(id);
        }

        public async Task<IEnumerable<NoteCategory>> GetAllAsync()
        {
            return await db.NoteCategories.GetAllAsync();
        }

        public async Task<NoteCategory> GetItemByIdAsync(int id)
        {
            return await db.NoteCategories.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(NoteCategory item)
        {
            await db.NoteCategories.UpdateAsync(item);
        }
    }
}
