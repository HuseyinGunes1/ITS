using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Repository;
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
		private readonly IServiceGeneric<IsIsci, CreateIsIsciDto> _serviceGeneric;
		private readonly ISumService< CreateIsIsciDto> _sumService;
		
		private readonly IGenericRepository<CreateIsciBilgiDto> _IsciBilgigenericRepository;
		
		public IsIsciService(IServiceGeneric<IsIsci, CreateIsIsciDto> serviceGeneric, ISumService< CreateIsIsciDto> sumService, IGenericRepository<CreateIsciBilgiDto> IsciBilgigenericRepository)
		{
			_IsciBilgigenericRepository = IsciBilgigenericRepository;
			_serviceGeneric = serviceGeneric;
			_sumService = sumService;
		}
		public  async Task<IEnumerable<CreateIsIsciDto>> AddIsIsciAsync(IEnumerable<CreateIsIsciDto> isIsci)
		{

			return await _serviceGeneric.AddAllAsync(isIsci);
		}

		public IEnumerable<CreateIsciBilgiDto> GunAllAsync(int isciId,bool durumu)
		{
			return _IsciBilgigenericRepository.GetAllJoin(isciId, durumu);
		}

		public int ToplamGunAsync(int isciId, bool durumu)
		{
			return _IsciBilgigenericRepository.GetAllToplamJoin(isciId, durumu);
			
		}

		
	}
}
