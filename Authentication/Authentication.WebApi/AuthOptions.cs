using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authentication.WebApi
{
    public class AuthOptions
    {
        public const string ISSUER = "MyCastle"; // издатель токена

        public const string AUDIENCE = "http://localhost:4200/"; // потребитель токена

        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации

        public const int LIFETIME = 10; // время жизни токена - 10 минут

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
