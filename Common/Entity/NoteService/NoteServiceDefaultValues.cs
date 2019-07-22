using System;

namespace Common.Entity.NoteService
{
    public static class NoteServiceDefaultValues
    {
        public static class DefaultNoteCategories
        {
            public static NoteCategory NoteCategory
            {
                get
                {
                    return new NoteCategory
                    {
                        Id = 0,
                        Name = "Категория",
                        Color = "000",
                        ImagePath = "https://st3.depositphotos.com/2903611/13027/i/950/depositphotos_130272574-stock-photo-phone-on-notepad-pen-coffee.jpg",
                        IsOn = true
                    };
                }                
            }

            public static NoteCategory VerificationAndCorrectioDataForCreating(NoteCategory item)
            {
                if(item.Id != 0) { item.Id = NoteCategory.Id; }

                if(string.IsNullOrEmpty(item.Name)) { item.Name = NoteCategory.Name; }

                if(string.IsNullOrEmpty(item.Color)) { item.Color = NoteCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.Color = NoteCategory.ImagePath; }

                if (item.IsOn == false) { item.IsOn = NoteCategory.IsOn; }

                return item;
            }

            public static NoteCategory VerificationAndCorrectioDataForEdit(NoteCategory item)
            {
                if (string.IsNullOrEmpty(item.Name)) { item.Name = NoteCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = NoteCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.Color = NoteCategory.ImagePath; }

                return item;
            }
        }

        public static class DefaultNote
        {
            public static Note Note
            {
                get
                {
                    return new Note
                    {
                        Id = 0,
                        Name = "",
                        Text = "",
                        LastChange = DateTime.Now,
                        NoteCategoryId = 0
                    };
                }
            }

            public static Note VerificationAndCorrectioDataForCreating(Note item)
            {
                if (item.Id != 0) { item.Id = Note.Id; }

                if (item.LastChange == null) item.LastChange = Note.LastChange;

                if (item.NoteCategoryId < 0) item.NoteCategoryId = Note.NoteCategoryId;

                return item;
            }

            public static Note VerificationAndCorrectioDataForEdit(Note item)
            {
                if (item.LastChange == null) item.LastChange = Note.LastChange;

                if (item.NoteCategoryId < 0) item.NoteCategoryId = Note.NoteCategoryId;

                return item;
            }
        }
    }
}
