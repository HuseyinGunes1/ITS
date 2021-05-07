using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsController
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class IsController : CustomBaseController
	{
		private readonly IIsService _isService;

		public IsController(IIsService isService)
		{

			_isService = isService;

		}
		[HttpPost]
		public async Task<Is> EkleIs(CreateIsDto Is)
		{
			return await _isService.AddIsAsync(Is);
		}
		[HttpGet]
		public async Task<IEnumerable<CreateIsDto>> Get()
		{
			return await _isService.GetIsAsync();
		}
	}
}
