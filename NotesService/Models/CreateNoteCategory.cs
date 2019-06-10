using System.ComponentModel.DataAnnotations;

namespace NotesService.Models
{
    public class CreateNoteCategory
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
