using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.SERVİCE.Security;
using ITS.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ITS.SERVİCE.Service
{
    public class CustomTokenService : ITokenService
    {
        private readonly UserManager<Cavus> _kullanici;
        private readonly CustomTokenOptions _customTokenOptions;
        public CustomTokenService(UserManager<Cavus> kullanici, IOptions<CustomTokenOptions> options)
        {
            _kullanici = kullanici;
            _customTokenOptions = options.Value;

        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaim(Cavus kullanici, List<String> Audience)
        {
            var userList = new List<Claim>//Token Pyloadında görmek istediğimiz verileri kaydediyoruz
            {
                new Claim(ClaimTypes.NameIdentifier,kullanici.Id),
                new Claim(ClaimTypes.Email,kullanici.Email),
                 new Claim(ClaimTypes.Name,kullanici.UserName),
                  new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())



            };
            userList.AddRange(Audience.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));//JwtRegisteredClaimNames.Aud kendisine istek yapılmasına uygunmudur
            return userList;
        }

        public TokenDto CreateToken(Cavus cavus)
        {
            var AccesTokenOmru = DateTime.Now.AddMinutes(_customTokenOptions.AccesTokenO);//Token ömrünü al
            var RefreshTokenOmru = DateTime.Now.AddMinutes(_customTokenOptions.RefreshTokenO);//Refresh token ömrünü al
            var SecuritKey = CustomSecurity.GetSymetricSecurityKey(_customTokenOptions.SecuritKey);
            SigningCredentials signingCredentials = new SigningCredentials(SecuritKey, SecurityAlgorithms.HmacSha256Signature);//imzamızı oluşturuyoruz
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                issuer: _customTokenOptions.Issuer,
                expires: AccesTokenOmru,
                notBefore: DateTime.Now,
                claims: GetClaim(cavus, _customTokenOptions.Audience),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccesTokenLifeTime = AccesTokenOmru,
                RefreshTokenLifeTime = RefreshTokenOmru
            };
            return tokenDto;
        }
    }
}
