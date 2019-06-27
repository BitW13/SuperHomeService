using NotesService.Dal.Repositories.Interfaces;

namespace NoteService.Dal.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        INoteRepository Notes { get; set; }

        INoteCategoryRepository NoteCategories { get; set; }
    }
}
