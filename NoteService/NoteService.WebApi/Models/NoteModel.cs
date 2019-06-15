using Common.Entity.NoteService;
using System.ComponentModel.DataAnnotations;

namespace NoteService.WebApi.Models
{
    public class NoteModel
    {
        [Required]
        public Note Note { get; set; }

        [Required]
        public NoteCategory NoteCategory { get; set; }
    }
}
