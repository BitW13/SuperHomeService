using Common.Entity.NoteService;
using NoteService.Bll.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.Notes
{
    public class NotePresenter : INotePresenter
    {
        private readonly IBusinessLogic db;

        public NotePresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public async Task<Note> CreateAsync(Note item)
        {
            return await db.Notes.CreateAsync(item);
        }

        public async Task<Note> DeleteAsync(int id)
        {
            Note note = await db.Notes.GetItemByIdAsync(id);

            if (note == null)
            {
                return null;
            }

            await db.Notes.DeleteAsync(note.Id);

            return note;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await db.Notes.GetAllAsync();
        }

        public async Task<IEnumerable<Note>> GetByNoteCategoryIdAsync(int noteCategoryId)
        {
            return await db.Notes.GetByNoteCategoryIdAsync(noteCategoryId);
        }

        public async Task<Note> GetItemByIdAsync(int id)
        {
            return await db.Notes.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Note item)
        {
            await db.Notes.UpdateAsync(item);
        }
    }
}
