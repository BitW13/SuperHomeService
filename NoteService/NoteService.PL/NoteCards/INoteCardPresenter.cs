using Common.Entity.NoteService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.NoteCards
{
    public interface INoteCardPresenter
    {
        Task<IEnumerable<NoteCard>> GetAllAsync();

        Task<NoteCard> GetItemByIdAsync(int id);

        Task<NoteCard> CreateAsync(Note item);

        Task<NoteCard> UpdateAsync(Note item);
    }
}
