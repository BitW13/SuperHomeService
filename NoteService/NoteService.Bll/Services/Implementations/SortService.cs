using Common.Entity.NoteService;
using NoteService.Bll.Services.Interfaces;
using NoteService.Dal.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Bll.Services.Implementations
{
    public class SortService : INoteSortService
    {
        private readonly IDataAccess db;

        public SortService(IDataAccess db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Note>> GetItemsByLastChangedAsync()
        {
            List<Note> notes = (await db.Notes.GetAllAsync()).ToList();

            return notes.OrderByDescending(x => x.LastChange);
        }
    }
}
