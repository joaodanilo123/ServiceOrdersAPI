using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Application.Interfaces;
using TarefasWeb.Configurations;
using System.Text;

namespace ServiceOrdersManagement.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public TokenDTO Login(LoginDTO loginDto)
        {
            if (loginDto.Username == "admin" && loginDto.Password == "123")
            {
                return new TokenDTO
                {
                    Token = GenerateJwtToken(loginDto.Username),
                };
            }

            throw new Exception("Não autorizado");
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = JwtSettings.MountJwtSettings(_config);
            Console.WriteLine(jwtSettings.Key.ToString());
            var key = jwtSettings.Key;
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings.ExpiresInMinutes)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
