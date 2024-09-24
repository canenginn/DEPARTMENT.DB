﻿
using DEPARTMENT.DB.Models;
using Microsoft.IdentityModel.Tokens;
using DEPARTMENT.API.JwtToken;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DEPARTMENT.API.JwtToken
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.SerialNumber,user.id.ToString()),
                    new Claim(ClaimTypes.Name,user.name+" "+user.lastName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,user.username.ToString()),
                    new Claim(ClaimTypes.Role,user.userTypeId.ToString())


                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int Decode(string token)
        {
            if (token == null)
            {
                return 0;
            }
            var keyenc = Encoding.ASCII.GetBytes(key);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyenc),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return Convert.ToInt32(claims.FindFirstValue(ClaimTypes.SerialNumber));
        }
    }
}
