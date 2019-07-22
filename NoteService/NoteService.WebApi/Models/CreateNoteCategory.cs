using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class CreateNoteCategory
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public bool IsOn { get; set; }
    }
}
