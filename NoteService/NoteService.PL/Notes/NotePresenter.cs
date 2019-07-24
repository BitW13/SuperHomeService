using Common.Entity.NoteService;
using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.Bll.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.Notes
{
    public class NotePresenter : INotePresenter
    {
        private readonly INoteEntityService db;

        public NotePresenter(INoteEntityService db)
        {
            this.db = db;
        }

        public async Task<Note> CreateAsync(Note item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<Note> DeleteAsync(int id)
        {
            Note note = await db.GetItemByIdAsync(id);

            if (note == null)
            {
                return null;
            }

            await db.DeleteAsync(note.Id);

            return note;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<Note>> GetByNoteCategoryIdAsync(int noteCategoryId)
        {
            return await db.GetByNoteCategoryIdAsync(noteCategoryId);
        }

        public async Task<Note> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Note item)
        {
            await db.UpdateAsync(item);
        }
    }
}
