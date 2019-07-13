using Common.Entity.NoteService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesService.Dal.Repositories.Interfaces
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<IEnumerable<Note>> GetByNoteCategoryId(int noteCategoryId);
    }
}
