using Common.Entity.NoteService;
using Common.Entity.ShoppingPlannerService;
using Common.Entity.TaskPlannerService;

namespace Common.Helpers
{
    public static class Constants
    {
        public static class DefaultTaskCategories
        {
            public static readonly TaskCategory TaskCategory = new TaskCategory
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
