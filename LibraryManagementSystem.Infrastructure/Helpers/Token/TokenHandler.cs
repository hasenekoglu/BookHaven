using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagementSystem.Infrastructure.Helpers.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.Dtos.Token CreateAccessToken(int minute)
        {
            Application.Dtos.Token token = new();
            
            //Securitykeyin simetriğini alıyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak tokenın ayarlarını veriyoruz
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials : signingCredentials
            );

            //Token oluşturucu sınıftan bir örnek alalım.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
