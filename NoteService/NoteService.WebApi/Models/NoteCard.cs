using Common.Entity.NoteService;

namespace NoteService.WebApi.Models
{
    public class NoteCard
    {
        public Note Note { get; set; }

        public NoteCategory NoteCategory { get; set; }
    }
}
