using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers.IsciController
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class IsciController : CustomBaseController
	{
		private readonly IIsciService _ısciService;
		private readonly IUserService _userService;
		public IsciController(IIsciService ısciService, IUserService userService)
		{
			_ısciService = ısciService;
			_userService = userService;
		}

		[Authorize]
		[HttpPost]
		public async Task<Isci> Add(CreateIsciDto dto)
		{
			return await _ısciService.AddIsciAsync(dto);
		}

		
		[HttpGet]
		public async Task<IEnumerable<CreateIsciDto>> Get()
		{
			var user = await _userService.GetUserByNameAsync("usame.215487");
			return await _ısciService.GetIsciAsync(user.data.GrupId);
		}

	}
}
