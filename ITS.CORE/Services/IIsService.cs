using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IIsService
	{
		public Task<Is> AddIsAsync(CreateIsDto Isci);
		public Task<IEnumerable<CreateIsDto>> GetIsAsync(int grupId);
	}
}
