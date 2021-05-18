using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.GiderController
{
	[ApiController]
	[Route("api/[controller]/[action]/{isciid}")]
	public class GiderController : CustomBaseController
	{
		private readonly IGiderService _giderService;

		public GiderController(IGiderService giderService)
		{

			_giderService = giderService;

		}
		[HttpPost]
		public async Task<Gider> AddGider(CreateGiderDto gider)
		{
			return await _giderService.AddIsAsync(gider);
		}
		[HttpGet]
		public  IEnumerable<Gider> AllGider(int isciid)
		{
			return _giderService.GetAllGiderAsync(isciid);
		}
		//[HttpGet]
		////Hatalı
		//public decimal GiderToplam(int isciid)
		//{
		//	return _giderService.GetGiderAsync(isciid);
		//}
	}
}
