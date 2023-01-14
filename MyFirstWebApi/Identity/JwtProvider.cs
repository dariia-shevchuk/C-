using Microsoft.IdentityModel.Tokens;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFirstWebApi.Identity
{
    public class JwtProvider : IJwtProvider
    {
        public AuthDto Create(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("123abcdef12312312=ABCD");
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("userId", userId.ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(45)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthDto
            {
                AccessToken = tokenHandler.WriteToken(token),
            };
        }
    }
}