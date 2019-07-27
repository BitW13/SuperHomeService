using Authentication.Dal.Repositories.Users;

namespace Authentication.Dal.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IUserRepository users)
        {
            Users = users;
        }
        public IUserRepository Users { get; set; }
    }
}
