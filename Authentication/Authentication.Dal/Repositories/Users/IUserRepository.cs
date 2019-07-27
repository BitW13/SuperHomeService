using Common.Entity.AuthenticationModel;
using System.Threading.Tasks;

namespace Authentication.Dal.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);

        Task<User> Login(User user);

        Task<User> Register(User user);

        bool CheckEmail(string email);
    }
}
