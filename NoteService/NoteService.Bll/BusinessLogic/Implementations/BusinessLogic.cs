using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.Bll.Services.Interfaces;

namespace NoteService.Bll.BusinessLogic.Implementations
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(INoteEntityService notes, INoteCategoryService noteCategories, ISortService sort)
        {
            Notes = notes;
            NoteCategories = noteCategories;
            Sort = sort;
        }

        public INoteEntityService Notes { get; set; }

        public INoteCategoryService NoteCategories { get; set; }

        public ISortService Sort { get; set; }
    }
}
