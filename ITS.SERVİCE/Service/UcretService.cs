using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class UcretService : IUcretService
	{
		private readonly IServiceGeneric<Ücret, CreateUcretDto> _serviceGeneric;
		public UcretService(IServiceGeneric<Ücret, CreateUcretDto> serviceGeneric)
		{
			_serviceGeneric = serviceGeneric;
		}

		public async Task<Ücret> AddUcretAsync(CreateUcretDto ücret)
		{
			return await _serviceGeneric.AddAsync(ücret);
		}

		public async Task<IEnumerable<CreateUcretDto>> GetUcretAsync()
		{
			return await _serviceGeneric.GetAllAsync();
		}
	}
}
