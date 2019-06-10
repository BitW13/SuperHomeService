using System.ComponentModel.DataAnnotations;

namespace NotesService.Models
{
    public class EditNoteCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
