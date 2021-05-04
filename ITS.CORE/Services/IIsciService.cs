using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IIsciService
	{
		public Task<Isci> AddIsciAsync(CreateIsciDto Isci);
		public Task<IEnumerable<CreateIsciDto>> GetIsciAsync(int grupId);
	}
}
