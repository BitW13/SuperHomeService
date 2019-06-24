using NoteService.Bll.Services.Interfaces;

namespace NoteService.Bll.BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {
        INoteEntityService Notes { get; set; }

        INoteCategoryService NoteCategories { get; set; }

        INoteSortService Sort { get; set; }
    }
}
