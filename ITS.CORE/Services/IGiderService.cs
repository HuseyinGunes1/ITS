using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IGiderService
	{
		
		public Task<Gider> AddIsAsync(CreateGiderDto gider);
		public decimal GetGiderAsync(int isciid);
		public IEnumerable<Gider> GetAllGiderAsync(int isciid);


	}
}
