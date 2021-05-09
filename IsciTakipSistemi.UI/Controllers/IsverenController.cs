using IsciTakipSistemi.UI.ApiService;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.SERVİCE.Mapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Controllers
{
	
	public class IsverenController : Controller
	{
		private readonly ApiServices _apiServices;


	public IsverenController(ApiServices apiServices)
	{
		_apiServices = apiServices;


	}
		public async  Task<IActionResult> Index()
		{

			IEnumerable<CreateIsverenDto> createIsverenDtos;
			List<CreateIsverenDto> IsverenDtos =new List<CreateIsverenDto>();

			var response = await _apiServices._httpClient.GetAsync("Isveren/Get");

			if (response.IsSuccessStatusCode)
			{
				createIsverenDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsverenDto>>(await response.Content.ReadAsStringAsync());

			}
			else
			{
				createIsverenDtos = null;
			}

			var DegerString = await response.Content.ReadAsStringAsync();
			var model = JsonConvert.DeserializeObject <List<CreateIsverenDto>>(DegerString);
			int j = 0;
			foreach(var i in model)
			{

				if (IsverenDtos.Count == 0)
				{
					IsverenDtos.Add(i);
				}
				else
				{
						if (i.IsverenAdi == IsverenDtos[j].IsverenAdi && i.IsverenSoyadi == IsverenDtos[j].IsverenSoyadi)
						{

						}
						else
						{
							IsverenDtos.Add(i);
						j++;
						}
				}
			}
			return View(IsverenDtos);
		}

		public async Task<IActionResult> IsverenDetay(string isverenadi,string isverensoyadi)
		{
			IEnumerable<CreateIsverenDto> createIsverenDtos;
			IEnumerable<CreateIsDto> createIsDtos;
			IEnumerable<CreateIsIsciDto> createIsIsciDtos;
			IEnumerable<CreateUcretDto> createUcretDtos;
			List<CreateIsverenBilgiDto> createIsverenBilgiDtos = new List<CreateIsverenBilgiDto>();
			List<int> IdIsveren = new List<int>();
			List<int> IdIs = new List<int>();
			//int grupId = 1;
			var response = await _apiServices._httpClient.GetAsync("Isveren/Get");
			var response2 = await _apiServices._httpClient.GetAsync("Is/Get");
			var response3 = await _apiServices._httpClient.GetAsync("IsIsci/Get");
			var response4 = await _apiServices._httpClient.GetAsync("Ucret/Get");
			if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode && response4.IsSuccessStatusCode)
			{
				createIsverenDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsverenDto>>(await response.Content.ReadAsStringAsync());
				createIsDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsDto>>(await response2.Content.ReadAsStringAsync());
				createIsIsciDtos = JsonConvert.DeserializeObject<IEnumerable<CreateIsIsciDto>>(await response3.Content.ReadAsStringAsync());
				createUcretDtos = JsonConvert.DeserializeObject<IEnumerable<CreateUcretDto>>(await response4.Content.ReadAsStringAsync());
			}
			else
			{
				createIsverenDtos = null;
				createIsDtos = null;
				createIsIsciDtos = null;
				createUcretDtos = null;
			}

			var DegerString = await response.Content.ReadAsStringAsync();
			var DegerString2 = await response2.Content.ReadAsStringAsync();
			var DegerString3 = await response3.Content.ReadAsStringAsync();
			var DegerString4 = await response4.Content.ReadAsStringAsync();
			var model = JsonConvert.DeserializeObject<List<CreateIsverenDto>>(DegerString);
			var model2 = JsonConvert.DeserializeObject<List<CreateIsDto>>(DegerString2);
			var model3 = JsonConvert.DeserializeObject<List<CreateIsIsciDto>>(DegerString3);
			var model4 = JsonConvert.DeserializeObject<List<CreateUcretDto>>(DegerString4);

			IdIsveren = (from r in model where r.IsverenAdi == isverenadi && r.IsverenSoyadi == isverensoyadi select r.IsverenId).ToList();
			for(int i = 0; i < IdIsveren.Count; i++)
			{
				IdIs.Add((from a in model2 join v in model on a.IsverenId equals v.IsverenId where a.IsverenId == IdIsveren[i] select a.IsId).SingleOrDefault());
			}
			for(int i = 0; i < IdIs.Count; i++)
			{
				var a = (from k in model3
						 join j in model2 on k.IsId equals j.IsId
						 where (k.IsId == IdIs[i]) && (k.Durumu == true)
						 group k by new { j.IsAdi, j.Tarih } into grp
						 select new
						 {
							 grp.Key.IsAdi,
							 grp.Key.Tarih,
							sayi= grp.Sum(x=>x.Yövmiye)
						 }).ToList();

				CreateIsverenBilgiDto createIsverenBilgiDtos2 = new CreateIsverenBilgiDto
				{
					IsAdi = a[0].IsAdi,
					Tarih = a[0].Tarih,
					Yövmiye = a[0].sayi

				};
				createIsverenBilgiDtos.Add(createIsverenBilgiDtos2);

			}

			double ToplamYövmiye= createIsverenBilgiDtos.Sum(x => x.Yövmiye);
			int ToplamGün = createIsverenBilgiDtos.Count;
			double ToplamÜcret = ToplamYövmiye * model4[0].IsUcreti;

			ViewBag.Yövmiye = ToplamYövmiye;
			ViewBag.ToplamGün = ToplamGün;
			ViewBag.Toplamücret = ToplamÜcret;

			return View(createIsverenBilgiDtos);
		}
	}
}
