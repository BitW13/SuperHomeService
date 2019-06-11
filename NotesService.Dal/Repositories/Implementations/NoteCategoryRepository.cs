using Common.Entity.NoteService;
using Microsoft.EntityFrameworkCore;
using NotesService.Dal.Contexts;
using NotesService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesService.Dal.Repositories.Implementations
{
    public class NoteCategoryRepository : INoteCategoryRepository
    {
        private readonly NoteServiceContext db;

        public NoteCategoryRepository(NoteServiceContext db)
        {
            this.db = db;
        }

        public async Task<NoteCategory> CreateAsync(NoteCategory item)
        {
            if (item != null)
            {
                db.NoteCategories.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<NoteCategory> DeleteAsync(int id)
        {
            NoteCategory item = await db.NoteCategories.FindAsync(id);

            if (item != null)
            {
                db.NoteCategories.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<NoteCategory>> GetAllAsync()
        {
            return await db.NoteCategories.ToListAsync();
        }

        public async Task<NoteCategory> GetItemByIdAsync(int id)
        {
            return await db.NoteCategories.FindAsync(id);
        }

        public async Task UpdateAsync(NoteCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
