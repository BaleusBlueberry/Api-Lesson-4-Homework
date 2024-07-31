using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api_Lesson_4_Homework.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api_Lesson_4_Homework.auth
{
    public class JwtTokenService(IOptions<JwtSettings> options) : IJwtTokenService
    {
        //now we have the secret+audience+issuer
        JwtSettings jwtSettings = options.Value;

        public async Task<string> CreateToken(AppUser user)
        {
            if (user is null || user.UserName is null)
            {
                throw new ArgumentException(nameof(user));
            }

            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            ];

            if (user.IsAdmin)
            {
                claims.Add(new Claim("IsAdmin", "true"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }



            //our secret key as bytes:
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

            //SingningCredentials = key + algorithm:
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,

                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
