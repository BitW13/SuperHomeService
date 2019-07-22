using Common.Entity.NoteService;
using Microsoft.EntityFrameworkCore;

namespace NotesService.Dal.Contexts
{
    public class NoteServiceContext : DbContext
    {
        public NoteServiceContext(DbContextOptions<NoteServiceContext> options)
            : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteCategory> NoteCategories { get; set; }
    }
}
