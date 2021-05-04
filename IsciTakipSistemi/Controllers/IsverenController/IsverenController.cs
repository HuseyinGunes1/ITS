using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsverenController
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class IsverenController :CustomBaseController
	{
		private readonly IIsverenService _ısverenService;
		
		public IsverenController(IIsverenService ısverenService)
		{

			_ısverenService = ısverenService;
			
		}

		
		[HttpPost]
		public async Task<Isveren> Add(CreateIsverenDto dto)
		{
			return await _ısverenService.CreateIsverenAsync(dto);
		}
		[HttpGet]
		public async Task<IEnumerable<CreateIsverenDto>> Get()
		{

			return await _ısverenService.GetIsverenAsync();
		}
	}
}
