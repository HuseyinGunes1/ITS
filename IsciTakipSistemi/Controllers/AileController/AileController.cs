using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.AileController
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AileController : CustomBaseController
	{
		private readonly IAileService _aileService;

		public AileController(IAileService aileService)
		{

			_aileService = aileService;

		}


		[HttpPost]
		public async Task<Aile> Add(CreateAileDto dto)
		{
			return await _aileService.AddIsAsync(dto);
		}
	}
}
