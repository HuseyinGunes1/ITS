using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class IsverenService : IIsverenService
	{
		private readonly IServiceGeneric<Isveren, CreateIsverenDto> _serviceGeneric;
		public IsverenService(IServiceGeneric<Isveren, CreateIsverenDto> serviceGeneric)
		{
			_serviceGeneric = serviceGeneric;
		}
		public async Task<Isveren> CreateIsverenAsync(CreateIsverenDto createUserDto)
		{
			return await _serviceGeneric.AddAsync(createUserDto);
		}

		public async Task<IEnumerable<CreateIsverenDto>> GetIsverenAsync()
		{
			return await _serviceGeneric.GetAllAsync();
		}
	}
}
