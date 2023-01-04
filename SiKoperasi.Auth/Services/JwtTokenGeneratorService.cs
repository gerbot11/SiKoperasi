using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiKoperasi.Auth.Commons;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;
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

        public TokenInfoDto GenerateToken(User user)
        {
            SigningCredentials signCredential = new
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
            };

            var roleClaim = user.UserRoles.Select(a => new Claim(ClaimTypes.Role, a.Role.Code));
            foreach (var item in roleClaim)
            {
                claims.Add(item);
            }

            JwtSecurityToken securityToken = new(claims: claims,
                                                 signingCredentials: signCredential,
                                                 issuer: jwtSettings.Issuer,
                                                 expires: DateTime.Now.AddDays(jwtSettings.ExpiredTime),
                                                 audience: jwtSettings.Audience);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            TokenInfoDto tokenInfo = new(token, securityToken.ValidFrom, securityToken.ValidTo);
            return tokenInfo;
        }
    }
}
