using ITS.CORE.Dto;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsIsciController
{
	[ApiController]
	[Route("api/[controller]")]
	public class IsIsciController :ControllerBase
	{
		private readonly IIsIsciService _isisciService;
		
		public IsIsciController(IIsIsciService isisciService)
		{
			_isisciService = isisciService;
			
		}

		[HttpPost]
		public async Task<IEnumerable<CreateIsIsciDto>> Add(IEnumerable<CreateIsIsciDto> isisci)
		{
			return await _isisciService.AddIsAsync(isisci);
		}
	}
}
