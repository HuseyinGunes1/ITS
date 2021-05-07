using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsIsciController
{
	[ApiController]
	[Route("api/[controller]/[action]/{isciid?}/{durumu?}")]
	public class IsIsciController :ControllerBase
	{
		private readonly IIsIsciService _isisciService;
		
		public IsIsciController(IIsIsciService isisciService)
		{
			_isisciService = isisciService;
			
		}

		[HttpPost]
		public async Task<IEnumerable<CreateIsIsciDto>> EkleIsIsci(IEnumerable<CreateIsIsciDto> isisci)
		{
			return await _isisciService.AddIsIsciAsync(isisci);
		}

		[HttpGet]
		public IEnumerable<CreateIsciBilgiDto> GunAll(int isciId, bool durumu)
		{
			return _isisciService.GunAllAsync(isciId, durumu);
		}

		[HttpGet]
		public int ToplamGunAll(int isciId, bool durumu)
		{
			return _isisciService.ToplamGunAsync(isciId, durumu)*100;
		}

		[HttpGet]
		public async Task<IEnumerable<IsIsci>> Get()
		{
			return await  _isisciService.GetIsIsciAsync();
		}
	}
}
