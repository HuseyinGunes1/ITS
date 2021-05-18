using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Repository;
using ITS.CORE.Services;
using ITS.CORE.UnitOfWork;
using ITS.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class AuthenticationService:IAuthenticationService

	{
		private readonly ITokenService tokenService;
		private readonly UserManager<Cavus> userManager;
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericRepository<KullaniciRefreshToken> refreshToken;//refresh token işlemleri için
		public AuthenticationService(ITokenService _tokenService, UserManager<Cavus> _userManager, IUnitOfWork _unitOfWork, IGenericRepository<KullaniciRefreshToken> _RefreshToken)
		{
			
			tokenService = _tokenService;
			userManager = _userManager;
			unitOfWork = _unitOfWork;
			refreshToken = _RefreshToken;
		}

		public async Task<TokenDto> CreateAccesTokenAsync(LoginDto loginDto)
		{
			if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));//gelen kullanıcı null ise hata fırlat
			var user = await userManager.FindByEmailAsync(loginDto.Email);//email adresine ait kullanıcı varsa user değişkenine kaydet
			//if (user == null) return Response<TokenDto>.Basarisiz("Email veya parola yanlış", 404);//eğer e posta ya ait kullanıcı yoksa hata ver
		

			if (!await userManager.CheckPasswordAsync(user, loginDto.Password))
			{
				//return Response<TokenDto>.Basarisiz("Email veya parola yanlış", 404);
			}

			var token = tokenService.CreateToken(user);
			var UserRefreshToken = await refreshToken.Where(x => x.CavusId== user.Id).SingleOrDefaultAsync();

			if (UserRefreshToken == null)
			{
				await refreshToken.AddAsync(new KullaniciRefreshToken { CavusId = user.Id, RefreshToken = token.RefreshToken, RefreshTokenOmru = token.RefreshTokenLifeTime });
			}
			else
			{
				UserRefreshToken.RefreshToken = token.RefreshToken;
				UserRefreshToken.RefreshTokenOmru = token.RefreshTokenLifeTime;

			}
			await unitOfWork.CommitAsync();
			return token;
		}

		public async Task<Response<TokenDto>> CreateByRefreshTokenAsync(string rrefreshToken)
		{
			var existRefreshToken = await refreshToken.Where(x => x.RefreshToken == rrefreshToken).SingleOrDefaultAsync();
			if (existRefreshToken == null)
			{
				return Response<TokenDto>.Basarisiz("refresh token bulunamadı", 404);
			}
			var user = await userManager.FindByIdAsync(existRefreshToken.CavusId);
			if (user == null)
			{
				return Response<TokenDto>.Basarisiz("refresh token bulunamadı", 404);
			}

			var tokenDto = tokenService.CreateToken(user);
			existRefreshToken.RefreshToken = tokenDto.RefreshToken;
			existRefreshToken.RefreshTokenOmru = tokenDto.RefreshTokenLifeTime;
			await unitOfWork.CommitAsync();
			return Response<TokenDto>.Basarili(tokenDto, 200);
		}

		public async Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string rrefreshToken)
		{
			var existRefreshToken = await refreshToken.Where(x => x.RefreshToken == rrefreshToken).SingleOrDefaultAsync();
			if (existRefreshToken == null)
			{
				return Response<NoDataDto>.Basarisiz("refresh token bulunamadı", 404);
			}

			refreshToken.Remove(existRefreshToken);

			await unitOfWork.CommitAsync();
			return Response<NoDataDto>.Basarili(200);
		}
	}
}
