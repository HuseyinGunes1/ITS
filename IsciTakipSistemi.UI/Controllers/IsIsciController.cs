using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.UnitOfWork;
using ITS.SERVİCE.Mapper;
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
	public class IsIsciController : Controller
	{
		private readonly ApiServices _apiServices;
	

		public IsIsciController(ApiServices apiServices)
		{
			_apiServices = apiServices;
			

		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<CreateIsciDto> createIsciDtos;
			

			var response = await _apiServices._httpClient.GetAsync("Isci/Get");

			if (response.IsSuccessStatusCode)
			{
				createIsciDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsciDto>>(await response.Content.ReadAsStringAsync());
				
			}
			else
			{
				createIsciDtos = null;
			}
			
			
			
			var TuppleNesnei = (createIsciDtos,new CreateIsverenDto(),new CreateIsDto(),new List<CreateIsIsciDto>());
			return View(TuppleNesnei);
		}


		[HttpPost]
		public async Task<IActionResult> Index([Bind(Prefix = "Item2")] CreateIsverenDto createIsverenDto, [Bind(Prefix = "Item3")] CreateIsDto createIsDto, [Bind(Prefix = "Item4")] IEnumerable<CreateIsIsciDto> createIsIsciDto)
		{
			createIsDto.GrupId = 1;//Userdan Alınacak
			var StringIsveren = new StringContent(JsonConvert.SerializeObject(createIsverenDto), Encoding.UTF8, "application/json");
			var response = _apiServices._httpClient.PostAsync("Isveren/Add", StringIsveren);
			var DegerString = await response.Result.Content.ReadAsStringAsync();
			var model = JsonConvert.DeserializeObject<Isveren>(DegerString);
			createIsDto.IsverenId = model.IsverenId;
			if (response.Result.IsSuccessStatusCode)
			{
				var StringIs = new StringContent(JsonConvert.SerializeObject(createIsDto), Encoding.UTF8, "application/json");
				var response2 = _apiServices._httpClient.PostAsync("Is/EkleIs", StringIs);
				var DegerString2 = await response2.Result.Content.ReadAsStringAsync();
				var model2 = JsonConvert.DeserializeObject<Is>(DegerString2);
				foreach (var i in createIsIsciDto)
				{
					i.IsId = model2.IsId;
				}
				if (response2.Result.IsSuccessStatusCode)
				{
					var StringIsIsci = new StringContent(JsonConvert.SerializeObject(createIsIsciDto), Encoding.UTF8, "application/json");
					var response3 = _apiServices._httpClient.PostAsync("IsIsci/EkleIsIsci", StringIsIsci);
					if (response3.Result.IsSuccessStatusCode)
					{
						return RedirectToAction("Index");
					}
					else
					{
						//IsIsci Eklenemedi Hatası
					}
				}
				else
				{
					//Is Eklenemedi hatası
				}
			}
			else
			{
				//Isveren Eklenemedi hatası
			}
			return  RedirectToAction("Index");
		}
	}
}
