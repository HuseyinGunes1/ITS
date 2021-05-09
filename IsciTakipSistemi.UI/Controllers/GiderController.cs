using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Controllers
{
	public class GiderController : Controller
	{
		private readonly ApiServices _apiServices;

		public GiderController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public async Task< IActionResult> Index()
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

			return View(createIsciDtos);
		}

		public async Task<IActionResult> GiderDetay(int isciId)
		{
			
			IEnumerable<Gider> Giderler;
			IEnumerable<CreateUcretDto> createUcretDtos;
			var response2 = await _apiServices._httpClient.GetAsync($"IsIsci/ToplamGunAll/{isciId}/{true}");
			var response3 = await _apiServices._httpClient.GetAsync($"Gider/AllGider/{isciId}");
			var response4 = await _apiServices._httpClient.GetAsync("Ucret/Get");
			if ( response2.IsSuccessStatusCode && response3.IsSuccessStatusCode && response4.IsSuccessStatusCode)
			{
				
				double k = JsonConvert.DeserializeObject<double>(await response2.Content.ReadAsStringAsync());
				Giderler = JsonConvert.DeserializeObject<IEnumerable<Gider>>(await response3.Content.ReadAsStringAsync());
				createUcretDtos = JsonConvert.DeserializeObject<IEnumerable<CreateUcretDto>>(await response4.Content.ReadAsStringAsync());
			}
			else
			{
				
				Giderler = null;
			}
			
			var DegerString2 = await response2.Content.ReadAsStringAsync();
			var DegerString3 = await response3.Content.ReadAsStringAsync();
			var DegerString4 = await response4.Content.ReadAsStringAsync();
			double model2 = JsonConvert.DeserializeObject<double>(DegerString2);
			IEnumerable<Gider> model3 = JsonConvert.DeserializeObject<IEnumerable<Gider>>(DegerString3);
			var model4 = JsonConvert.DeserializeObject<List<CreateUcretDto>>(DegerString4);
			double gider = 0;
			foreach (var i in model3)
			{
				gider = gider + Convert.ToDouble(i.GiderTutar);
			}
			
			ViewBag.Ucret = (model4[0].IsUcreti*model2)*0.9;
			ViewBag.Gider = gider;
			ViewBag.Total = ((model4[0].IsUcreti * model2) * 0.9) - (gider);
			return View(Giderler);
		}

	}
}
