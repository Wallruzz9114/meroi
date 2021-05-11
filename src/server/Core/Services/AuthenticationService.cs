using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities;
using Data;
using Data.Extensions;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        [UseAppDbContext]
        public async Task<string> Register(string email, string password, AppDbContext dbContext)
        {
            var roles = new List<string>();
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            var id = -1;

            if (user.Email == email)
            {
                var validPassword = BC.Verify(password, user.Password);

                if (validPassword)
                {
                    if (user.Id % 2 == 0) roles.Add("admin");
                    else roles.Add("logged");
                    id = user.Id;
                }
            }

            if (roles.Count > 0)
                return GetAccessToken(email, id.ToString(), roles.ToArray());

            throw new AuthenticationException();
        }

        private static string GetAccessToken(string email, string userId, string[] roles)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(StringGenerator.GenerateRandomString()));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, email)
            };

            claims = claims.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                "issuer",
                "audience",
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: credentials
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }
    }
}