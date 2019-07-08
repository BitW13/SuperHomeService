using Common.Entity.NoteService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.Bll.Services.Interfaces
{
    public interface INoteEntityService : IService<Note>
    {
        Task<IEnumerable<Note>> GetByNoteCategoryIdAsync(int id);
    }
}
