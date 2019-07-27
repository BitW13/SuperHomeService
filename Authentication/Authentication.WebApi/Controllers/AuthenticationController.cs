using Authentication.Dal.DataAccess;
using Authentication.WebApi.Models;
using AutoMapper;
using Common.Entity.AuthenticationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IDataAccess db;
        private readonly IMapper mapper;

        public AuthenticationController(IDataAccess db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody]LoginUser loginUser)
        {
            var identity = await GetIdentity(mapper.Map<User>(loginUser));

            if (identity == null)
            {
                return BadRequest();
            }

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.Now,
                    claims: identity.Claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        [HttpPut("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser)
        {
            User user = await db.Users.Register(mapper.Map<User>(registerUser));

            if(user != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("checkEmail")]
        public async Task<IActionResult> CheckEmail([FromBody] string email)
        {
            return Ok();
        }

        private async Task<ClaimsIdentity> GetIdentity(User loginUser)
        {
            User user = await db.Users.Login(loginUser);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}