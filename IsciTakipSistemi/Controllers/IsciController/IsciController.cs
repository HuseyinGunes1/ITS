using ITS.CORE.Dto;
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
	[Route("api/[controller]")]
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
		public async Task<IActionResult> Add(CreateIsciDto dto)
		{
			return ActionInstance(await _ısciService.AddIsciAsync(dto));
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var user = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
			return ActionInstance(await _ısciService.GetIsciAsync(user.data.GrupId));
		}

	}
}
