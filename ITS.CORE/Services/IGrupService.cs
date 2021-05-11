using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IGrupService
	{
		public Task<Grup> AddGrupAsync(CreateGrupDto grup);

		public Task<IEnumerable<Grup>> GetAllGrupAsync();

		public Task<Response<NoDataDto>> Update(CreateGrupDto grup, int grupid);

		public Task<Response<NoDataDto>> Remove(int grupid);
		public Task<Grup> GetAllGrupid(int grupid);
	}
}
