using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.AileController
{
	[ApiController]
	[Route("api/[controller]/[action]/{aileid?}")]
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
		[HttpGet]
		public async Task<IEnumerable<Aile>> Get()
		{
			return await _aileService.GetAllAileAsync();
		}
		[HttpGet]
		public async Task<Aile> GetId(int aileid)
		{
			return await _aileService.GetAllAileid(aileid);
		}
		[HttpPost]
		public async Task<Response<NoDataDto>> Update(CreateAileDto dto, int aileid)
		{
			return await _aileService.Update(dto, aileid);
		}
	}
}
