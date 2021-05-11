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
	public class AileService:IAileService
	{
		private readonly IServiceGeneric<Aile, CreateAileDto> _serviceGeneric;
		public AileService(IServiceGeneric<Aile, CreateAileDto> serviceGeneric)
		{
			_serviceGeneric = serviceGeneric;
		}

		public async Task<Aile> AddIsAsync(CreateAileDto aile)
		{
			return await _serviceGeneric.AddAsync(aile);
		}
		public async Task<IEnumerable<Aile>> GetAllAileAsync()
		{
			return await _serviceGeneric.GetAllAsync2();
		}
		public async Task<Aile> GetAllAileid(int aileid)
		{
			return await _serviceGeneric.GetIdAsync2(aileid);
		}
		public async Task<Response<NoDataDto>> Update(CreateAileDto aile, int aileid)
		{
			return await _serviceGeneric.Update(aile, aileid);
		}

	}
}
