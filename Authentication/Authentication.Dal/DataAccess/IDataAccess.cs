using Authentication.Dal.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Dal.DataAccess
{
    public interface IDataAccess
    {
        IUserRepository Users { get; set; }
    }
}
