using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class GiderService:IGiderService
	{
		private readonly IServiceGeneric<Gider, CreateGiderDto> _serviceGeneric;
		private readonly ISumService< CreateGiderDto> _sumService;
		public GiderService(IServiceGeneric<Gider, CreateGiderDto> serviceGeneric, ISumService< CreateGiderDto> sumService)
		{
			_serviceGeneric = serviceGeneric;
			_sumService = sumService;
		}

		public async Task<Gider> AddIsAsync(CreateGiderDto gider)
		{
			return await _serviceGeneric.AddAsync(gider);
		}

		public IEnumerable<Gider> GetAllGiderAsync(int isciid)
		{
			var liste = _serviceGeneric.Where(x => x.IsciId == isciid);
			
			return liste;
		}

		public decimal GetGiderAsync(int isciid)
		{
			var liste = _serviceGeneric.Where(x => x.IsciId == isciid);
			 


			return liste.Sum(x => x.GiderTutar);


		}
	}
}
