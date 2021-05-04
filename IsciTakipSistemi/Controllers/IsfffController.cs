using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IsfffController :CustomBaseController
	{
		private readonly IIsService _ısService;
		private readonly IUserService _userService;
		public IsfffController(IIsService ısService, IUserService userService)
		{
			_ısService = ısService;
			_userService = userService;
		}

		
		[HttpPost]
		public async Task<Is> Add(CreateIsDto dto)
		{
			return await _ısService.AddIsAsync(dto);
		}

		[Authorize]
		[HttpGet]
		public async Task<IEnumerable<CreateIsDto>> Get()
		{
			var user = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
			return await _ısService.GetIsAsync(user.data.GrupId);
		}
	}
}
