using ITS.CORE.Dto;
using ITS.CORE.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IUcretService
	{
		public Task<Ücret> AddUcretAsync(CreateUcretDto ücret);
		public Task<IEnumerable<CreateUcretDto>> GetUcretAsync();
	}
}
