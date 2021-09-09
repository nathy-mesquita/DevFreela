using System;
using System.Text;
using System.Security.Claims;
using DevFreela.Core.Services;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration) 
            => _configuration = configuration;

        public string GenereteJwtToken(string email, string role)
        {
            //Todo: 1. Pegar as chaves cadastradas no appsettings
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            
            //Todo: 2. Converte a chave de acesso em bytes
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            //Todo: 3. Criar as credentials para assinar o token com todas informações (algoritmos e dados do token)
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Todo: 4. Definir as Claims, informações sobre o usuário a qual o token pertence
            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            //Todo: 5. Inicializar o Token (JwtSecurityToken)
            var token = new JwtSecurityToken(
                                issuer: issuer, 
                                audience: audience, 
                                expires: DateTime.Now.AddHours(8),
                                signingCredentials: credentials,
                                claims: claims);

            //Todo: 6. Gerar a cadeira de caracteres 
            var tokenHandler = new JwtSecurityTokenHandler();

            //Todo: 7. Gerar o token em formato string
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}