using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.GrupController
{
	[ApiController]
	[Route("api/[controller]/[action]/{grupid?}")]
	public class GrupController : Controller
	{
		private readonly IGrupService _grupService;
		
		public GrupController(IGrupService grupService)
		{
			_grupService = grupService;
		}
		[HttpPost]
		public async Task<Grup> Add(CreateGrupDto dto)
		{
			return await _grupService.AddGrupAsync(dto);
		}


		[HttpGet]
		public async Task<IEnumerable<Grup>> Get()
		{
			return await _grupService.GetAllGrupAsync();
		}
		[HttpGet]
		public async Task<Grup> GetId(int grupid)
		{
			return await _grupService.GetAllGrupid(grupid);
		}
		//[HttpDelete]
		//public async Task<Response<NoDataDto>> Remove(int grupid)
		//{
		//	return await _grupService.Remove(grupid);
		//}

		[HttpPost]
		public async Task<Response<NoDataDto>> Update(CreateGrupDto dto,int grupid)
		{
			return await _grupService.Update(dto,grupid);
		}
	}
}
