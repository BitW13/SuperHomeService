using Common.Entity.NoteService;
using Microsoft.EntityFrameworkCore;
using NotesService.Dal.Contexts;
using NotesService.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesService.Dal.Repositories.Implementations
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteServiceContext db;

        public NoteRepository(NoteServiceContext db)
        {
            this.db = db;
        }

        public async Task<Note> CreateAsync(Note item)
        {
            if (item != null)
            {
                db.Notes.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Note> DeleteAsync(int id)
        {
            Note item = await db.Notes.FindAsync(id);

            if (item != null)
            {
                db.Notes.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await db.Notes.ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetByNoteCategoryId(int noteCategoryId)
        {
            var notes = (await GetAllAsync()) as List<Note>;

            return notes.FindAll(note => note.NoteCategoryId == noteCategoryId);
        }

        public async Task<Note> GetItemByIdAsync(int id)
        {
            return await db.Notes.FindAsync(id);
        }

        public async Task UpdateAsync(Note item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
