using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Infrastructure.Security
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _config;

        public JwtProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string IDusuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, IDusuario),
        };
            string keyString = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no se encontró en appsettings.json");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
