using Common.Entity.NoteService;
using NoteService.Bll.Services.Interfaces;
using NotesService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.Bll.Services.Implementations
{
    public class NoteEntityService : INoteEntityService
    {
        private readonly INoteRepository db;

        public NoteEntityService(INoteRepository db)
        {
            this.db = db;
        }

        public async Task<Note> CreateAsync(Note item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<Note> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<Note>> GetByNoteCategoryIdAsync(int noteCategoryId)
        {
            return await db.GetByNoteCategoryId(noteCategoryId);
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
