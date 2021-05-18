using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Areas.AdminPaneli.Controllers
{
	[Area("AdminPaneli")]
	public class KullaniciController : Controller
	{
		private readonly ApiServices _apiServices;
		public KullaniciController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public IActionResult
			Index()
		{
			//IEnumerable<CavusDto> createcavusDtos;

			////var accessToken = HttpContext.Session.GetString("JWTToken");
			////_apiServices._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			//var response = await _apiServices._httpClient.GetAsync("User/GetUser2");

			//if (response.IsSuccessStatusCode)
			//{
			//	createcavusDtos = JsonConvert.DeserializeObject<IEnumerable<CavusDto>>(await response.Content.ReadAsStringAsync());

			//}
			//else
			//{
			//	createcavusDtos = null;
			//}

			return View();
			
		}
		[HttpGet]
		public async Task<IActionResult> KullaniciEkle()
		{
			IEnumerable<CreateGrupDto> creategrupDtos;
			var response = await _apiServices._httpClient.GetAsync("Grup/Get");

			if (response.IsSuccessStatusCode)
			{
				creategrupDtos = JsonConvert.DeserializeObject<IEnumerable<CreateGrupDto>>(await response.Content.ReadAsStringAsync());
			}
			else
			{
				creategrupDtos = null;
			}
			var TuppleNesnesi = (new CreateUserDto(), creategrupDtos);
			return View(TuppleNesnesi);
		}

		[HttpPost]
		public async Task<IActionResult> KullaniciEkle([Bind(Prefix = "Item1")] CreateUserDto createUserDto)
		{
			var StringGrup = new StringContent(JsonConvert.SerializeObject(createUserDto), Encoding.UTF8, "application/json");
			var response = await _apiServices._httpClient.PostAsync("User/Add", StringGrup);
			//var DegerString = await response.Result.Content.ReadAsStringAsync();
			//var model = JsonConvert.DeserializeObject<Cavus>(DegerString);
			if (response.IsSuccessStatusCode)
			{

			}
			return View();
			
		}

		
	}
}
