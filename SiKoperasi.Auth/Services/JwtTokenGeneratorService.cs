using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiKoperasi.AppService.Contract;
using SiKoperasi.Auth.Commons;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiKoperasi.Auth.Services
{
    public class JwtTokenGeneratorService : IJwtTokenGeneratorService
    {
        private readonly JwtSettings jwtSettings;

        public JwtTokenGeneratorService(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(string userid, string username)
        {
            SigningCredentials signCredential = new
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userid),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, username)
            };

            JwtSecurityToken securityToken = new(claims: claims,
                                                 signingCredentials: signCredential,
                                                 issuer: jwtSettings.Issuer,
                                                 expires: DateTime.Now.AddMinutes(jwtSettings.ExpiredTime),
                                                 audience: jwtSettings.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
