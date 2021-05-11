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
	public class GrupController : Controller
	{
		private readonly ApiServices _apiServices;

		public GrupController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public async Task<IActionResult> Index()
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

			return View(creategrupDtos);

			
		}
		[HttpGet]
		public IActionResult GrupEkle()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GrupEkle(CreateGrupDto createGrupDto)
		{
			var StringGrup = new StringContent(JsonConvert.SerializeObject(createGrupDto), Encoding.UTF8, "application/json");
			var response = _apiServices._httpClient.PostAsync("Grup/Add", StringGrup);
			var DegerString = await response.Result.Content.ReadAsStringAsync();
			var model = JsonConvert.DeserializeObject<Grup>(DegerString);
			if (response.Result.IsSuccessStatusCode)
			{

			}
			return View();
		}

		//public async Task<IActionResult> GrupSil(int grupid)
		//{
		//	var response = await _apiServices._httpClient.DeleteAsync($"Grup/Remove/{grupid}");
		//	if (response.IsSuccessStatusCode)
		//	{

		//	}
		//	return RedirectToAction("Index");
		//}
		[HttpGet]
		public async Task<IActionResult> GrupUpdate(int grupid)
		{
			CreateGrupDto creategrupDtos;


			var response = await _apiServices._httpClient.GetAsync($"Grup/GetId/{grupid}");

			if (response.IsSuccessStatusCode)
			{
				creategrupDtos = JsonConvert.DeserializeObject<CreateGrupDto>(await response.Content.ReadAsStringAsync());


			}
			else
			{
				creategrupDtos = null;
			}

			return View(creategrupDtos);
			
		}
		[HttpPost]
		public  IActionResult GrupUpdate(CreateGrupDto createGrupDto)
		{
			var StringGrup = new StringContent(JsonConvert.SerializeObject(createGrupDto), Encoding.UTF8, "application/json");
			int grupid = createGrupDto.GrupId;
			var response = _apiServices._httpClient.PostAsync($"Grup/Update/{grupid}", StringGrup);
		
			if (response.Result.IsSuccessStatusCode)
			{

			}
			return RedirectToAction("Index");
		}
	}
}
