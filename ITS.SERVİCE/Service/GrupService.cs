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
	public class GrupService : IGrupService
	{
		private readonly IServiceGeneric<Grup, CreateGrupDto> _serviceGeneric;

		public GrupService(IServiceGeneric<Grup, CreateGrupDto> serviceGeneric)
		{
			_serviceGeneric = serviceGeneric;
		}
		public async Task<Grup> AddGrupAsync(CreateGrupDto grup)
		{
			return await _serviceGeneric.AddAsync(grup);
		}

		public async Task<IEnumerable<Grup>> GetAllGrupAsync()
		{
			return await _serviceGeneric.GetAllAsync2();
		}
		public async Task<Grup> GetAllGrupid(int grupid)
		{
			return await _serviceGeneric.GetIdAsync2(grupid);
		}
		public async Task<Response<NoDataDto>> Remove(int grupid)
		{
			return await _serviceGeneric.Remove(grupid);
		}

		public async Task<Response<NoDataDto>> Update(CreateGrupDto grup, int grupid)
		{
			return await _serviceGeneric.Update(grup, grupid);
		}
	}
}
