using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class UcretController : CustomBaseController
	{
		private readonly IUcretService _ısciService;
	
		public UcretController(IUcretService ısciService )
		{
			_ısciService = ısciService;
			
		}

		[HttpPost]
		public async Task<Ücret> Add(CreateUcretDto dto)
		{
			return await _ısciService.AddUcretAsync(dto);
		}

		[HttpGet]
		public async Task<IEnumerable<CreateUcretDto>> Get()
		{
			return await _ısciService.GetUcretAsync();
		}
	}
}
