using ITS.CORE.Dto;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IIsIsciService
	{
		public Task<Response<IEnumerable<CreateIsIsciDto>>> AddIsAsync(List<CreateIsIsciDto> IsIsci);
		public Task<int> GeldigiGunAsync(int isciId);
		public Task<int> GelmedigiGunAsync(int isciId);
		public Task<Response<IEnumerable<CreateIsciBilgiDto>>> GeldigiGunAllAsync(int isciId);
		public Task<Response<IEnumerable<CreateIsciBilgiDto>>> GelmedigiGunAllAsync(int isciId);
	}
}
