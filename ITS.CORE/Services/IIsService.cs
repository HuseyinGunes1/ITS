using ITS.CORE.Dto;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IIsService
	{
		public Task<Response<CreateIsDto>> AddIsAsync(CreateIsDto Isci);
		public Task<Response<IEnumerable<CreateIsDto>>> GetIsAsync(int grupId);
	}
}
