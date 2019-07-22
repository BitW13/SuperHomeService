using Common.Entity.NoteService;
using Common.Patterns.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.Notes
{
    public interface INotePresenter : IPresenter<Note>
    {
        Task<IEnumerable<Note>> GetByNoteCategoryIdAsync(int noteCategoryId);
    }
}
