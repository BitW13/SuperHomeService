using Common.Entity.AuthenticationModel;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Dal.Contexts
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
