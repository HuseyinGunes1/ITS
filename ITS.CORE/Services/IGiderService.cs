using ITS.CORE.Dto;
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
		
		public Task<Response<CreateGiderDto>> AddIsAsync(CreateGiderDto gider);
		public Task<decimal> GetGiderAsync(int isciid);
		public Task<Response<IEnumerable<CreateGiderDto>>> GetAllGiderAsync(int isciid);
		
	}
}
