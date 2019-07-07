using Common.Entity.NoteService;

namespace NoteService.Bll.Helpers
{
    public static class Constants
    {
        public static class DefaultNoteCategories
        {
            public static readonly NoteCategory NoteCategory = new NoteCategory
            {
                Id = 0,
                Color = "000",
                Name = "Категория",
                IsOn = true
            };
        }
    }
}
