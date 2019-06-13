using NoteService.Dal.DataAccess.Interfaces;
using NotesService.Dal.Repositories.Interfaces;

namespace NoteService.Dal.DataAccess.Implementations
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(INoteRepository notes, INoteCategoryRepository noteCategories)
        {
            Notes = notes;
            NoteCategories = noteCategories;
        }

        public INoteRepository Notes { get; set; }

        public INoteCategoryRepository NoteCategories { get; set; }
    }
}
