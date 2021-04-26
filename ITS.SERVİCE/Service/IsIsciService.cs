using ITS.CORE.Dto;
using ITS.CORE.Services;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class IsIsciService : IIsIsciService
	{
		public Task<Response<IEnumerable<CreateIsIsciDto>>> AddIsAsync(List<CreateIsIsciDto> IsIsci)
		{
			throw new NotImplementedException();
		}

		public Task<Response<IEnumerable<CreateIsciBilgiDto>>> GeldigiGunAllAsync(int isciId)
		{
			throw new NotImplementedException();
		}

		public Task<int> GeldigiGunAsync(int isciId)
		{
			throw new NotImplementedException();
		}

		public Task<Response<IEnumerable<CreateIsciBilgiDto>>> GelmedigiGunAllAsync(int isciId)
		{
			throw new NotImplementedException();
		}

		public Task<int> GelmedigiGunAsync(int isciId)
		{
			throw new NotImplementedException();
		}
	}
}
