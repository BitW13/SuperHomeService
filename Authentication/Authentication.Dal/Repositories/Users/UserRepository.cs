using Authentication.Dal.Contexts;
using Common.Entity.AuthenticationModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Dal.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext db;

        public UserRepository(AuthContext db)
        {
            this.db = db;
        }

        public bool CheckEmail(string email)
        {
            if(email != null)
            {
                User user = db.Users.SingleOrDefault(u => u.Email == email);

                if(user != null)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<User> GetUserById(int userId)
        {
            User user = await db.Users.FindAsync(userId);

            if(user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<User> Login(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);

                await db.SaveChangesAsync();

                return user;
            }

            return null;
        }

        public async Task<User> Register(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);

                await db.SaveChangesAsync();

                return user;
            }

            return null;
        }
    }
}
