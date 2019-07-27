using Common.Entity.NoteService;
using NoteService.Bll.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.PL.NoteCards
{
    public class NoteCardPresenter : INoteCardPresenter
    {
        private readonly IBusinessLogic db;

        public NoteCardPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public async Task<NoteCard> CreateAsync(Note item)
        {
            Note note = await db.Notes.CreateAsync(item);

            return await GetItemByIdAsync(note.Id);
        }

        public async Task DeleteAsync(int id)
        {
            Note note = await db.Notes.GetItemByIdAsync(id);

            if (note == null)
            {
                return;
            }

            await db.Notes.DeleteAsync(id);
        }

        public async Task<IEnumerable<NoteCard>> GetAllAsync()
        {
            IEnumerable<Note> notes = await db.Sort.GetItemsByLastChangedAsync();

            List<NoteCard> cards = new List<NoteCard>();

            foreach (var note in notes)
            {
                NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

                cards.Add(new NoteCard { Note = note, NoteCategory = category });
            }

            return cards;
        }

        public async Task<NoteCard> GetItemByIdAsync(int id)
        {
            Note note = await db.Notes.GetItemByIdAsync(id);

            if (note == null)
            {
                return null;
            }

            NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

            NoteCard card = new NoteCard
            {
                Note = note,
                NoteCategory = category
            };

            return card;
        }

        public async Task<NoteCard> UpdateAsync(Note item)
        {
            await db.Notes.UpdateAsync(item);

            return await GetItemByIdAsync(item.Id);
        }
    }
}
