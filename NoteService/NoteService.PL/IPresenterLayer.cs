using NoteService.PL.NoteCards;
using NoteService.PL.NoteCategories;
using NoteService.PL.Notes;

namespace NoteService.PL
{
    public interface IPresenterLayer
    {
        INotePresenter Notes { get; set; }

        INoteCategoryPresenter NoteCategories { get; set; }

        INoteCardPresenter Cards { get; set; }
    }
}
