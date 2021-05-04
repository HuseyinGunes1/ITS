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
	public class IsciService : IIsciService
	{
		private readonly IServiceGeneric<Isci, CreateIsciDto> _serviceGeneric;
		public IsciService(IServiceGeneric<Isci, CreateIsciDto> serviceGeneric )
		{
			_serviceGeneric = serviceGeneric;
		}

		public async Task<Isci> AddIsciAsync(CreateIsciDto Isci)
		{
			return await _serviceGeneric.AddAsync(Isci);
			
		}

		public async Task<IEnumerable<CreateIsciDto>> GetIsciAsync(int grupId)
		{
			return await _serviceGeneric.GetAllAsync();
		}
	}
}
