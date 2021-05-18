using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Controllers
{
	public class LoginController : Controller
	{
		private readonly ApiServices _apiServices;
		public LoginController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async  Task<IActionResult> Index(LoginDto loginDto)
		{
			TokenDto a;
			var StringToken = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
			var response = _apiServices._httpClient.PostAsync("Auth/CreateToken", StringToken);
			if (response.Result.IsSuccessStatusCode)
			{
				string token = await response.Result.Content.ReadAsStringAsync();
				a = JsonConvert.DeserializeObject<TokenDto>(token);
				HttpContext.Session.SetString("JWTToken",a.AccessToken);
				return RedirectToAction("Index", "IsIsci");
			}
			else
			{
				return View();
			}
			
		}
	}
}
