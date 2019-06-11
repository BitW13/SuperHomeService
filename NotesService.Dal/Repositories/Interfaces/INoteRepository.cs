using Common.Entity.NoteService;
using Common.Patterns.Repository;

namespace NotesService.Dal.Repositories.Interfaces
{
    public interface INoteRepository : IRepository<Note>
    {
    }
}
