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
		public Task<IEnumerable<CreateIsIsciDto>> AddIsIsciAsync(IEnumerable<CreateIsIsciDto> IsIsci);
		public int ToplamGunAsync(int isciId, bool durumu);
		public IEnumerable<CreateIsciBilgiDto> GunAllAsync(int isciId, bool durumu);
		
	}
}
