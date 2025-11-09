using Ecom.Services.AuthAPI.Helpers;
using Ecom.Services.AuthAPI.Interface;
using Ecom.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecom.Services.AuthAPI.Service
{
    public class JWTGeneratorService : IJWTGeneratorService
    {
        private readonly JwtOptions _jwtOption;

        public JWTGeneratorService(IOptions<JwtOptions> jwtOption)
        {
            _jwtOption = jwtOption.Value;
        }   

        public string GenerateToken(User userObj)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOption.Secret);

            var claim = new List<Claim>
             {
                 new Claim(JwtRegisteredClaimNames.Email, userObj.Email),
                 new Claim(JwtRegisteredClaimNames.Sub, userObj.Id),
                 new Claim(JwtRegisteredClaimNames.Name, userObj.UserName),
             };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOption.Audience,
                Issuer = _jwtOption.Issuer,
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
