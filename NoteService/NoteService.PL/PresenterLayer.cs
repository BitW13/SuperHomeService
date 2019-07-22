using NoteService.PL.NoteCards;
using NoteService.PL.NoteCategories;
using NoteService.PL.Notes;

namespace NoteService.PL
{
    public class PresenterLayer : IPresenterLayer
    {
        public PresenterLayer(INotePresenter notes, INoteCategoryPresenter noteCategories, INoteCardPresenter cards)
        {
            Notes = notes;
            NoteCategories = noteCategories;
            Cards = cards;
        }
        public INotePresenter Notes { get; set; }

        public INoteCategoryPresenter NoteCategories { get; set; }

        public INoteCardPresenter Cards { get; set; }
    }
}
