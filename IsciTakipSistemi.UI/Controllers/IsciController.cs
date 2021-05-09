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
	public class IsciController : Controller
	{
		private readonly ApiServices _apiServices;

		public IsciController(ApiServices apiServices)
		{
			_apiServices = apiServices;
		}
		public async Task<IActionResult> IndexAsync()
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


		public async Task<IActionResult> IsciDetay(int isciId, bool durumu)
		{
			IEnumerable<CreateIsciBilgiDto> createIsciBilgiDtos;
			IEnumerable<CreateUcretDto> createUcretDtos;
			IEnumerable<Gider> GiderBilgi;
			var response = await _apiServices._httpClient.GetAsync($"IsIsci/GunAll/{isciId}/{durumu}");
			var response2 = await _apiServices._httpClient.GetAsync($"IsIsci/ToplamGunAll/{isciId}/{true}");
			var response3 = await _apiServices._httpClient.GetAsync($"Gider/AllGider/{isciId}");
			var response4 = await _apiServices._httpClient.GetAsync("Ucret/Get");
			if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode && response4.IsSuccessStatusCode)
			{
				createIsciBilgiDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsciBilgiDto>>(await response.Content.ReadAsStringAsync());
				decimal k= JsonConvert.DeserializeObject<decimal>(await response2.Content.ReadAsStringAsync());
				GiderBilgi= JsonConvert.DeserializeObject<IEnumerable<Gider>>(await response3.Content.ReadAsStringAsync());
				createUcretDtos = JsonConvert.DeserializeObject<IEnumerable<CreateUcretDto>>(await response4.Content.ReadAsStringAsync());
			}
			else
			{
				createIsciBilgiDtos = null;
			}
			var DegerString = await response.Content.ReadAsStringAsync();
			var DegerString2 = await response2.Content.ReadAsStringAsync();
			var DegerString3 = await response3.Content.ReadAsStringAsync();
			var DegerString4 = await response4.Content.ReadAsStringAsync();

			IEnumerable<CreateIsciBilgiDto> model = JsonConvert.DeserializeObject<IEnumerable<CreateIsciBilgiDto>>(DegerString);
			decimal model2 = JsonConvert.DeserializeObject<decimal>(DegerString2);
			IEnumerable<Gider> model3 = JsonConvert.DeserializeObject<IEnumerable<Gider>>(DegerString3);
			var model4 = JsonConvert.DeserializeObject<List<CreateUcretDto>>(DegerString4);
			decimal gider = 0;
			foreach(var i in model3)
			{
				gider = gider +i.GiderTutar;
			}
			if (durumu == true)
			{
				
				ViewBag.Yövmiye = model.Sum(x => x.Yövmiye);
				ViewBag.Ucret = Convert.ToDouble(model2) * model4[0].IsUcreti;
				ViewBag.Total = (Convert.ToDouble(model2) * model4[0].IsUcreti) * 0.9;

			}
			else
			{
				ViewBag.Yövmiye = model.Count();
				ViewBag.Ucret = Convert.ToDouble(model2) * model4[0].IsUcreti;
				ViewBag.Total = (Convert.ToDouble(model2) * model4[0].IsUcreti) * 0.9;
				//ViewBag.Ucret = model.Sum(x => x.Yövmiye);
				//ViewBag.Gider = model2 * 100;
			}
			
			return View(createIsciBilgiDtos);
		}

		
	}
}
