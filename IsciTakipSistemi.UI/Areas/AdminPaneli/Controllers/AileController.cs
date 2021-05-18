using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Areas.AdminPaneli.Controllers
{
	[Area("AdminPaneli")]
	public class AileController : Controller
	{
		private readonly ApiServices _apiServices;
		public AileController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<CreateAileDto> createaileDtos;

			var accessToken = HttpContext.Session.GetString("JWTToken");
			_apiServices._httpClient.DefaultRequestHeaders.Authorization  = new AuthenticationHeaderValue("Bearer", accessToken);
			var response = await _apiServices._httpClient.GetAsync("Aile/Get");

			if (response.IsSuccessStatusCode)
			{
				createaileDtos = JsonConvert.DeserializeObject<IEnumerable<CreateAileDto>>(await response.Content.ReadAsStringAsync());

			}
			else
			{
				createaileDtos = null;
			}

			return View(createaileDtos);
		}

		[HttpGet]
		public async Task<IActionResult> AileEkle()
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
			var TuppleNesnesi = (new CreateAileDto(), creategrupDtos);
			return View(TuppleNesnesi);
		}
		[HttpPost]
		public async Task<IActionResult> AileEkle([Bind(Prefix = "Item1")] CreateAileDto createAileDto)
		{
			var StringGrup = new StringContent(JsonConvert.SerializeObject(createAileDto), Encoding.UTF8, "application/json");
			var response = _apiServices._httpClient.PostAsync("Aile/Add", StringGrup);
			var DegerString = await response.Result.Content.ReadAsStringAsync();
			var model = JsonConvert.DeserializeObject<Aile>(DegerString);
			if (response.Result.IsSuccessStatusCode)
			{

			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> AileUpdate(int aileid)
		{
			CreateAileDto createaileDtos;
			IEnumerable<CreateGrupDto> creategrupDtos;
			var response = await _apiServices._httpClient.GetAsync($"Aile/GetId/{aileid}");
			var response2 = await _apiServices._httpClient.GetAsync("Grup/Get");
			if (response.IsSuccessStatusCode)
			{
				createaileDtos = JsonConvert.DeserializeObject<CreateAileDto>(await response.Content.ReadAsStringAsync());
				creategrupDtos = JsonConvert.DeserializeObject<IEnumerable<CreateGrupDto>>(await response2.Content.ReadAsStringAsync());

			}
			else
			{
				createaileDtos = null;
				creategrupDtos = null;
			}
			var TuppleNesnesi = (createaileDtos, creategrupDtos);
			return View(TuppleNesnesi);
		}


		[HttpPost]
		public IActionResult AileUpdate([Bind(Prefix = "Item1")]  CreateAileDto createaileDto)
		{
			var StringGrup = new StringContent(JsonConvert.SerializeObject(createaileDto), Encoding.UTF8, "application/json");
			int aileid = createaileDto.AileId;
			var response = _apiServices._httpClient.PostAsync($"Aile/Update/{aileid}", StringGrup);

			if (response.Result.IsSuccessStatusCode)
			{

			}
			return RedirectToAction("Index");
		}
	}
}
