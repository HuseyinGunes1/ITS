using ITS.CORE.Dto;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
   public interface IAuthenticationService  //kullanıcıdan gerekli bilgileri alacağımız ve bu bilgiler doğrultusunda geriye token döneceğimiz servistir
    {
        Task<Response<TokenEntity>> CreateAccesTokenAsync(LoginDto loginDto);
        Task<Response<TokenEntity>> CreateByRefreshTokenAsync(string refreshToken);//kullanıcı refresh token alması için servis

        Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken);// kullanıcı log out olduğu zaman kullanıcı için refreh token varsa bunu null a set et
    }
}
