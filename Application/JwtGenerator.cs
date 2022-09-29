using Application.Options;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;

        public JwtGenerator(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(UserAccount user)
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()) };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = AuthOptions.AUDIENCE,
                Issuer = AuthOptions.ISSUER,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.Add(TimeSpan.FromHours(2)),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
