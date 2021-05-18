using ITS.CORE.Dto;
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
	[Route("api/[controller]/[action]")]
	public class UserController :CustomBaseController
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost]
		public async Task<IActionResult> Add(CreateUserDto createUserDto)
		{
			return ActionInstance(await _userService.CreateUserAsync(createUserDto));
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetUser()
		{
			return ActionInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
		}

	}
}
