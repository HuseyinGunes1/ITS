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
	public class IsService:IIsService
	{
		private readonly IServiceGeneric<Is, CreateIsDto> _serviceGeneric;
		public IsService(IServiceGeneric<Is, CreateIsDto> serviceGeneric)
		{
			_serviceGeneric = serviceGeneric;
		}

		public async Task<Is> AddIsAsync(CreateIsDto Is)
		{
			return await _serviceGeneric.AddAsync(Is);
		}

		public async Task<IEnumerable<CreateIsDto>> GetIsAsync(int grupId)
		{
			return await _serviceGeneric.GetAllAsync();
		}
	}
}
