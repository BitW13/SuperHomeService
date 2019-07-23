using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class CreateNoteCategory
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public string ImagePath { get; set; }

        public bool IsOn { get; set; }
    }
}
