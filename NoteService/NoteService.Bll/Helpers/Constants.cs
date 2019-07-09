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
                Name = "Категория",
                Color = "000",                
                ImagePath = "https://st3.depositphotos.com/2903611/13027/i/950/depositphotos_130272574-stock-photo-phone-on-notepad-pen-coffee.jpg",
                IsOn = true
            };
        }
    }
}
