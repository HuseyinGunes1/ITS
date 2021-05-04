using ITS.CORE.Dto;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IServiceGeneric<T, TDto> where T : class where TDto : class
	{
        Task<Response<TDto>> GetIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(TDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> Update(TDto entity, int id);
        Task<IEnumerable<TDto>> AddAllAsync(IEnumerable<TDto> liste);
    }
}
