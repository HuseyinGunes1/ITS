using ITS.CORE.Dto;
using ITS.SERVİCE.Mapper;
using ITS.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.ApiService
{
	public class ApiServices
	{
		public readonly HttpClient _httpClient;
		
		public ApiServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		
	}
}
