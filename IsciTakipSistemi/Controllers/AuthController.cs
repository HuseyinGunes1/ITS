using ITS.CORE.Dto;
using ITS.CORE.Services;
using ITS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AuthController :CustomBaseController
	{
		
		private readonly IAuthenticationService _authenticationService;
		public AuthController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost]
		public async Task<TokenDto> CreateToken(LoginDto loginDto)
		{
			var result = await _authenticationService.CreateAccesTokenAsync(loginDto);
			return result;
		}
	}
}
