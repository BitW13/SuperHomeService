using System.ComponentModel.DataAnnotations;

namespace NotesService.WebApi.Models
{
    public class EditNoteCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool IsOn { get; set; }
    }
}
