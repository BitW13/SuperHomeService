using Common.Entity.NoteService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.Bll.Services.Interfaces
{
    public interface ISortService
    {
        Task<IEnumerable<Note>> GetNotesByLastChangedAsync();
    }
}
