namespace NotesService.WebApi.Models
{
    public class EditNoteCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string ImagePath { get; set; }

        public bool IsOn { get; set; }
    }
}
