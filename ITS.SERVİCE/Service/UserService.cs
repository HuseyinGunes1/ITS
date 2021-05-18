using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.CORE.UnitOfWork;
using ITS.SERVİCE.Mapper;
using ITS.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class UserService : IUserService
	{
		private readonly UserManager<Cavus> _kullanici;
		

		public UserService(UserManager<Cavus> userManager, IUnitOfWork unitOfWork)
		{
			_kullanici = userManager;
			

		}
		public async Task<Response<CavusDto>> CreateUserAsync(CreateUserDto createUserDto)
		{
			var user = new Cavus { Email = createUserDto.Email, UserName = createUserDto.UserName ,GrupId=createUserDto.GrupId};
			var result = await _kullanici.CreateAsync(user, createUserDto.Password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(x => x.Description).ToList();
				return Response<CavusDto>.Basarisiz(new ErrorDto(errors, true), 400);

			}

			return Response<CavusDto>.Basarili(ObjectMapper.MapperIslemleri.Map<CavusDto>(user), 200);
		}
		public async Task<Response<CavusDto>> GetUserByNameAsync(string userName)
		{
			var user = await _kullanici.FindByNameAsync(userName);
			
			if (user == null)
			{
				return Response<CavusDto>.Basarisiz("user name not found", 404);

			}
			return Response<CavusDto>.Basarili(ObjectMapper.MapperIslemleri.Map<CavusDto>(user), 200);
		}

		//public async Task<IEnumerable< CavusDto>> GetUser()
		//{
		//	return await _Kullanici2.GetAllAsync();
		//}

		//public async Task<Response<NoDataDto>> Update(CavusDto dto,string id)
		//{
		//	return await _Kullanici2.UpdateKullanici(dto, id);
		//}
	}
}
