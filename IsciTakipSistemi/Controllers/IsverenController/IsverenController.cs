using ITS.CORE.Dto;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsverenController
{
	[ApiController]
	[Route("api/[controller]")]
	public class IsverenController :CustomBaseController
	{
		private readonly IIsverenService _ısverenService;
		
		public IsverenController(IIsverenService ısverenService)
		{

			_ısverenService = ısverenService;
			
		}

		
		[HttpPost]
		public async Task<IActionResult> Add(CreateIsverenDto dto)
		{
			return ActionInstance(await _ısverenService.CreateIsverenAsync(dto));
		}
	}
}
